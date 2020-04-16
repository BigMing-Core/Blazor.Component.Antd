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
        private string _sliderTrackStyleTemplate = "left: {0}%; right: auto; width: {1}%;";
        private string _sliderTrackStyle = string.Empty;
        private readonly OriginalStyleHelper _sliderTrackStyleHelper = new OriginalStyleHelper();

        private MouseEvent? _preLeftLocation = null;
        private bool _leftHandleMouseDown = false;
        private string _leftHandleStyleTemplate = "left: {0}%; right: auto; transform: translateX(-50%);";
        private string _leftHandleStyle = string.Empty;

        private MouseEvent? _preRightLocation = null;
        private bool _rightHandleMouseDown = false;
        private string _rightHandleStyleTemplate = "left: {0}%; right: auto; transform: translateX(-50%);";
        private string _rightHandleStyle = string.Empty;
        private readonly OriginalStyleHelper _rightHandleStyleHelper = new OriginalStyleHelper();


        private double _currentLeftValue = 0;
        private double _currentRightValue = 0;


        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string ValueFormatter { get; set; } = "{0:F2}";

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
        }


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
            _rightHandleStyle = string.Format(_rightHandleStyleTemplate, _currentRightValue.ToString("F2"));
        }
        private void HandleDisabled()
        {
            _classHelper
                    .AddOrRemove(_silderDisabledClassName, () => Disabled);
        }

        public void BindMouseEvent()
        {
            ElementInfo.BindMouseMoveEvent($"body", nameof(RightHandleMove), this, true);
            ElementInfo.BindMouseUpEvent($"body", nameof(RightHandleMouseUp), this, true); 
            ElementInfo.BindMouseDownEvent($"righthandle_{IdentityKey}", nameof(RightHandleMouseDown), this, true);
        }

        [JSInvokable]
        public void RightHandleMouseUp(WindowEvent _)
        {
            _rightHandleMouseDown = false;
        }

        [JSInvokable]
        public void RightHandleMouseDown(WindowEvent _)
        {
            if (this.Disabled)
            {
                return;
            }
            _rightHandleMouseDown = true;
        }

        [JSInvokable]
        public async void RightHandleMove(WindowEvent e)
        {
            if (!_rightHandleMouseDown)
            {
                return;
            }
            _currentRightValue = ((double)e.MouseEvent.ClientX) / ((double)e.CurrentWindowInfo.InnerSize.Width) * ((double)100);
            _rightHandleStyle = string.Format(_rightHandleStyleTemplate, _currentRightValue);
            _sliderTrackStyle = string.Format(_sliderTrackStyleTemplate, _currentLeftValue, _currentRightValue);
            this.Flush();
        }
    }
}
