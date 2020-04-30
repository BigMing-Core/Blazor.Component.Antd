using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class Input
    {

        private const string _staticClassName = "ant-input";
        private const string _staticWrapperClassName = "ant-input-affix-wrapper";
        private const string _staticWrapperFocusedClassName = "ant-input-affix-wrapper-focused";
        private const string _staticWrapperDisabledClassName = "ant-input-affix-wrapper-disabled";
        private const string _staticDisableClassName = "ant-input-disabled";
        private const string _staticLGClassName = "ant-input-lg";
        private const string _staticSMClassName = "ant-input-sm";
        private readonly ClassNameHelper _wrapperClassNameHelper = new ClassNameHelper();
        private string _wrapperClassName = "";
        private string _defaultValue = "";
        private string _userInputValue;





        public Input()
        {
            _classHelper.SetStaticClass(_staticClassName);
            _wrapperClassNameHelper.SetStaticClass(_staticWrapperClassName);
        }

        [Parameter]
        public string DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (_hasFirstRender)
                {
                    return;
                }
                _defaultValue = value;
            }
        }

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public InputSize Size { get; set; } = InputSize.Default;

        [Parameter]
        public RenderFragment Prefix { get; set; }


        [Parameter]
        public RenderFragment Suffix { get; set; }


        [Parameter]
        public RenderFragment AddonBefore { get; set; }

        [Parameter]
        public RenderFragment AddonAfter { get; set; }

        public string Value { get => _userInputValue; }

        [Parameter]
        public Action<string> OnChange { get; set; }
        [Parameter]
        public Action<string> OnPressEnter{ get; set; }


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
        [JSInvokable]
        public async void HandleOnChange()
        {
            _userInputValue = await ElementInfo.GetElementValue($"LNInput_{IdentityKey}");
            OnChange?.Invoke(_userInputValue);
        }

        [JSInvokable]
        public async void HandleKeyPress(KeyboardEvent _)
        {
            _userInputValue = await ElementInfo.GetElementValue($"LNInput_{IdentityKey}"); 
            OnPressEnter?.Invoke(_userInputValue);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
        }


        private void BindEvent()
        {
            ElementInfo.BindFocusEvent($"LNInput_{IdentityKey}", nameof(HandleOnFocus), this);
            ElementInfo.BindBlurEvent($"LNInput_{IdentityKey}", nameof(HandleOnBlur), this);
            ElementInfo.BindKeypressEvent($"LNInput_{IdentityKey}", nameof(HandleKeyPress), this, new[] { 13 });
            ElementInfo.BindChangeEvent($"LNInput_{IdentityKey}", nameof(HandleOnChange), this);
        }




        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleInputSize();
            HandleWrapperClassName();
        }
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindEvent();
            }
        }

        private void HandleWrapperClassName()
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
            _wrapperClassName = _wrapperClassNameHelper.AddOrRemove(_staticWrapperDisabledClassName, () => Disabled).Build();
        }

    }
}
