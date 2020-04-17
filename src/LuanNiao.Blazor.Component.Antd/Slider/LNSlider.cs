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


        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string TipFormatter { get; set; } = "{0:F2}";

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

        private void HandleValue()
        {
            _rightHandleStyle = string.Format(_handleStyleTemplate, _currentRightValue.ToString("F2"),(_rightHandleMouseDown? _topLevelIndex:""));
            _leftHandleStyle = string.Format(_handleStyleTemplate, _currentLeftValue.ToString("F2"), (_leftHandleMouseDown ? _topLevelIndex : ""));
            _sliderTrackStyle = string.Format(_sliderTrackStyleTemplate, _currentLeftValue.ToString("F2"), (_currentRightValue - _currentLeftValue).ToString("F2"));
        }

        private void HandleDisabled()
        {
            _classHelper
                    .AddOrRemove(_silderDisabledClassName, () => Disabled);
        }

        private void BindMouseEvent()
        {
            ElementInfo.BindMouseUpEvent($"body", nameof(HandleMouseUp), this);

            ElementInfo.BindMouseMoveEvent($"body", nameof(RightHandleMove), this);
            ElementInfo.BindMouseMoveEvent($"body", nameof(LeftHandleMove), this);
            ElementInfo.BindMouseDownEvent($"lefthandle_{IdentityKey}", nameof(LeftHandleMouseDown), this);
            ElementInfo.BindMouseDownEvent($"righthandle_{IdentityKey}", nameof(RightHandleMouseDown), this);
        }


        [JSInvokable]
        public void HandleMouseUp()
        {
            _leftHandleMouseDown = _rightHandleMouseDown = false;
        }

        [JSInvokable]
        public void RightHandleMouseDown()
        {
            if (this.Disabled)
            {
                return;
            }
            _rightHandleMouseDown = true;
        }

        [JSInvokable]
        public void LeftHandleMouseDown()
        {
            if (this.Disabled)
            {
                return;
            }
            _leftHandleMouseDown = true;
        }

        [JSInvokable]
        public async void LeftHandleMove(WindowEvent e)
        {
            if (!_leftHandleMouseDown)
            {
                return;
            }
            var elementInfo = await ElementInfo.GetElementRectsByID($"maindiv_{IdentityKey}");
            _currentLeftValue = ((double)(e.MouseEvent.ClientX - elementInfo.X)) / ((double)elementInfo.Width) * ((double)100);
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
        public async void RightHandleMove(WindowEvent e)
        {
            if (!_rightHandleMouseDown)
            {
                return;
            }
            var elementInfo = await ElementInfo.GetElementRectsByID($"maindiv_{IdentityKey}");
            _currentRightValue = ((double)(e.MouseEvent.ClientX - elementInfo.X)) / ((double)(elementInfo.Width)) * ((double)100);
#if DEBUG
            Console.WriteLine($"{e.MouseEvent.ClientX}");
            Console.WriteLine($"{elementInfo.Width}");
#endif
            if (_currentRightValue - _currentLeftValue <= 0)
            {
                _currentRightValue = _currentLeftValue;
            }
            else if (_currentRightValue > 100)
            {
                _currentRightValue = 100;
            }
            HandleValue();
            OnChange?.Invoke(_currentLeftValue, _currentRightValue);
            this.Flush();
        }
    }
}
