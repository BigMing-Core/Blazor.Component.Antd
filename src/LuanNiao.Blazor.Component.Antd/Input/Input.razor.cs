using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class Input
    {

        private const string _staticClassName = "ant-input";
        private const string _staticWrapperClassName = "ant-input-affix-wrapper";
        private const string _staticWrapperFocusedClassName = "ant-input-affix-wrapper-focused";
        private const string _staticDisableClassName = "ant-input-disabled";
        private const string _staticLGClassName = "ant-input-lg";
        private const string _staticSMClassName = "ant-input-sm";
        private readonly ClassNameHelper _wrapperClassNameHelper = new ClassNameHelper();
        private string _wrapperClassName = "";


        public Input()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public InputSize Size { get; set; } = InputSize.Default;

        [Parameter]
        public RenderFragment Prefix { get; set; }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
        }


        private void BindEvent()
        {
            ElementInfo.BindFocusEvent($"LNInput_{IdentityKey}", nameof(HandleOnFocus), this);
            ElementInfo.BindBlurEvent($"LNInput_{IdentityKey}", nameof(HandleOnBlur), this);
        }

        [JSInvokable]
        public void HandleOnFocus()
        {
            _wrapperClassName = _wrapperClassNameHelper.AddCustomClass(_staticWrapperFocusedClassName).Build();
            this.Flush();
        }

        [JSInvokable]
        public void HandleOnBlur()
        {
            _wrapperClassName = _wrapperClassNameHelper.RemoveCustomClass(_staticWrapperFocusedClassName).Build();
            this.Flush();
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleInputSize();
            if (Prefix != null)
            {
                _wrapperClassNameHelper.SetStaticClass(_staticWrapperClassName);
                HandlePrefixSize();
            }
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindEvent();
            }
        }

        private void HandlePrefixSize()
        {
            switch (Size)
            {
                case InputSize.Large:
                    _wrapperClassNameHelper.AddCustomClass(_staticLGClassName).Build();
                    break;
                case InputSize.Small:
                    _wrapperClassNameHelper.AddCustomClass(_staticSMClassName).Build();
                    break;
                case InputSize.Default:
                default:
                    break;
            }
            _wrapperClassName = _wrapperClassNameHelper.Build();
        }

        private void HandleInputSize()
        {
            switch (Size)
            {
                case InputSize.Large:
                    _classHelper.AddCustomClass(_staticLGClassName);
                    break;
                case InputSize.Small:
                    _classHelper.AddCustomClass(_staticSMClassName);
                    break;
                case InputSize.Default:
                default:
                    break;
            }
        }


        private void HandleDisabled()
        {
            _classHelper.AddOrRemove(_staticDisableClassName, () => Disabled);
        }

    }
}
