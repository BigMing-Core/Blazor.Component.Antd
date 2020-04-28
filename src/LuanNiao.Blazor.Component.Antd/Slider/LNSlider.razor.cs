using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Slider
{
    public partial class LNSlider
    {
        private const string _sliderStaticClassName = "ant-slider";
        private const string _silderDisabledClassName = "ant-slider-disabled";
        /// <summary>
        /// left: 0%; right: auto; width: 14%;
        /// </summary>
        private readonly string _sliderTrackStyleTemplate = "left: {0}%; right: auto; width: {1}%;";
        private readonly string _topLevelIndex = "z-index:9999;";

        private readonly string _handleStyleTemplate = "left: {0}%; right: auto; transform: translateX(-50%);{1}";
        private string _sliderTrackStyle = string.Empty;
        private readonly OriginalStyleHelper _sliderTrackStyleHelper = new OriginalStyleHelper();

        private bool _leftHandleMouseDown = false;
        private string _leftHandleStyle = string.Empty;

        private bool _rightHandleMouseDown = false;
        private string _rightHandleStyle = string.Empty;
        private readonly OriginalStyleHelper _rightHandleStyleHelper = new OriginalStyleHelper();


        private double _currentLeftValue = 0;
        private double _currentRightValue = 0;

        private double _halfOfStep = 0;
        private double _rangeSize = 0;

        private ElementRects _elementRects;

        [Parameter]
        public double Max { get; set; } = 100;
        [Parameter]
        public double Min { get; set; } = 0;
        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string TipFormatter { get; set; } = "{0:F2}";

        [Parameter]
        public bool Range { get; set; } = false;

        [Parameter]
        public double? Step { get; set; } = null;

        [Parameter]
        public double Value { get; set; }

        [Parameter]
        public Action<double, double> OnChange { get; set; }

        public LNSlider()
        {
            _classHelper
                .SetStaticClass(_sliderStaticClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleDisabled();
            HandleValue();
            CalcStepInfo();
        }



        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindMouseEvent();
            }
        }

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            HandleElementDefaultInfo();
            return base.OnAfterRenderAsync(firstRender);
        }
        private async void HandleElementDefaultInfo()
        {

            _elementRects = await ElementInfo.GetElementRectsByID($"maindiv_{IdentityKey}");
        }


        private void HandleValue()
        {
            _rightHandleStyle = string.Format(_handleStyleTemplate, _currentRightValue.ToString("F2"), (_rightHandleMouseDown ? _topLevelIndex : ""));
            _leftHandleStyle = string.Format(_handleStyleTemplate, _currentLeftValue.ToString("F2"), (_leftHandleMouseDown ? _topLevelIndex : ""));
            _sliderTrackStyle = string.Format(_sliderTrackStyleTemplate, _currentLeftValue.ToString("F2"), (_currentRightValue - _currentLeftValue).ToString("F2"));
        }

        private void CalcStepInfo()
        {
            _halfOfStep = (Step == null ? 1 : Step.Value) / 2;
            _rangeSize = Max - Min;
        }

        private void HandleDisabled()
        {
            _classHelper
                    .AddOrRemove(_silderDisabledClassName, () => Disabled);
        }

        private void BindMouseEvent()
        {
            BodyEventHub.MouseUp += HandleMouseUp;
            ElementInfo.BindMouseDownEvent($"lefthandle_{IdentityKey}", nameof(LeftHandleMouseDown), this);
            ElementInfo.BindMouseDownEvent($"righthandle_{IdentityKey}", nameof(RightHandleMouseDown), this);
        }



        [JSInvokable]
        public async void OnElementResize()
        {
            _elementRects = await ElementInfo.GetElementRectsByID($"maindiv_{IdentityKey}");
#if DEBUG
            Console.WriteLine(nameof(OnElementResize));
#endif
        }


        private double PrettifyValue(double value)
        {
            var data = Min + (value * (_rangeSize) / 100);
            return Math.Round(data, 6);
        }


        [JSInvokable]
        public void HandleMouseUp(WindowEvent _)
        {
            _leftHandleMouseDown = _rightHandleMouseDown = false;

            BodyEventHub.MouseMove -= RightHandleMove;
            BodyEventHub.MouseMove -= LeftHandleMove;
        }

        [JSInvokable]
        public void RightHandleMouseDown()
        {
            if (this.Disabled)
            {
                return;
            }
            _rightHandleMouseDown = true;

            BodyEventHub.MouseMove += RightHandleMove;
        }

        [JSInvokable]
        public void LeftHandleMouseDown()
        {
            if (this.Disabled)
            {
                return;
            }
            _leftHandleMouseDown = true;
            BodyEventHub.MouseMove += LeftHandleMove;
        }



        [JSInvokable]
        public void LeftHandleMove(WindowEvent e)
        {
            if (!_leftHandleMouseDown)
            {
                return;
            }
            var percentOfElement = ((e.MouseEvent.ClientX - _elementRects.X)) / (_elementRects.Width);
            double targetStepNum = 0;

            var numberOfRange = _rangeSize * percentOfElement;
            var _step = Step == null ? 1 : Step.Value;
            var remainderOfStep = numberOfRange % _step;

            if (remainderOfStep >= _halfOfStep)
            {
                targetStepNum = numberOfRange + _step - remainderOfStep;
            }
            else
            {
                targetStepNum = numberOfRange - remainderOfStep;
            }
            percentOfElement = targetStepNum * 100 / _rangeSize;

            _currentLeftValue = percentOfElement;

            if (_currentRightValue - _currentLeftValue <= 0)
            {
                _currentLeftValue = _currentRightValue;
            }
            else if (_currentLeftValue < 0)
            {
                _currentLeftValue = 0;
            }
            HandleValue();
            OnChange?.Invoke(_currentLeftValue, _currentRightValue);
            this.Flush();
        }

        [JSInvokable]
        public void RightHandleMove(WindowEvent e)
        {
            if (!_rightHandleMouseDown)
            {
                return;
            }
            var percentOfElement = ((e.MouseEvent.ClientX - _elementRects.X)) / (_elementRects.Width);
            double targetStepNum = 0;

            var numberOfRange = _rangeSize * percentOfElement;
            var _step = Step == null ? 1 : Step.Value;
            var remainderOfStep = numberOfRange % _step;

            if (remainderOfStep >= _halfOfStep)
            {
                targetStepNum = numberOfRange + _step - remainderOfStep;
            }
            else
            {
                targetStepNum = numberOfRange - remainderOfStep;
            }
            if (Step != null && (targetStepNum + Min) > Max)
            {
                return;
            }
            percentOfElement = targetStepNum * 100 / _rangeSize;
            _currentRightValue = percentOfElement;
            if (_currentRightValue - _currentLeftValue <= 0)
            {
                _currentRightValue = _currentLeftValue;
            }
            else if (_currentRightValue > 100)
            {
                _currentRightValue = 100;
            }
            HandleValue();
            OnChange?.Invoke(PrettifyValue(_currentLeftValue), PrettifyValue(_currentRightValue));
            this.Flush();
        }
    }
}
