using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class Search
    {

        private const string _staticClassName = "ant-input";
        private const string _staticWrapperClassName = "ant-input-affix-wrapper ant-input-search ";
        private const string _staticWrapperFocusedClassName = "ant-input-affix-wrapper-focused";
        private const string _staticWrapperDisabledClassName = "ant-input-affix-wrapper-disabled";
        private const string _staticDisableClassName = "ant-input-disabled";
        private const string _staticLGClassName = "ant-input-lg";
        private const string _staticSMClassName = "ant-input-sm";
        //private readonly ClassNameHelper _classHelper = new ClassNameHelper();
        private readonly ClassNameHelper _inputClassHelper = new ClassNameHelper();

        private string InputClass { get => _inputClassHelper.Build(); }
        private string _wrapperClassName = "";
        private string _defaultValue = "";
        private string _userInputValue;





        public Search()
        {
            _inputClassHelper.SetStaticClass(_staticClassName);
            _classHelper.SetStaticClass(_staticWrapperClassName);
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

        [Parameter]
        public bool UseBtnMod { get; set; }

        public string Value { get => _userInputValue; }

        [Parameter]
        public Action<string> OnChange { get; set; }
        [Parameter]
        public Action<string> OnPressEnter { get; set; }
        [Parameter]
        public Action<string> OnSearch { get; set; }


        [OnFocusEvent]
        public void HandleOnFocus()
        {
            _wrapperClassName = _classHelper.AddCustomClass(_staticWrapperFocusedClassName).Build();
            this.Flush();
        }

        [OnBlurEvent]
        public void HandleOnBlur()
        {
            _wrapperClassName = _classHelper.RemoveCustomClass(_staticWrapperFocusedClassName).Build();
            this.Flush();
        }
        [OnChangeEvent]
        public async void HandleOnChange()
        {
            _userInputValue = await ElementInfo.GetElementValue($"LNInput_{IdentityKey}");
            OnChange?.Invoke(_userInputValue);            
        }

        [OnKeypressEvent]
        public async void HandleKeyPress(KeyboardEvent e)
        {
            if (e.KeyCode==13)
            {
                _userInputValue = await ElementInfo.GetElementValue($"LNInput_{IdentityKey}");
                OnPressEnter?.Invoke(_userInputValue);
                OnSearch?.Invoke(_userInputValue);
            }
        }

        private async void OnIconClicked()
        {
            if (Disabled)
            {
                return;
            }
            _userInputValue = await ElementInfo.GetElementValue($"LNInput_{IdentityKey}");
            OnSearch?.Invoke(_userInputValue);

        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
        }


        private void BindEvent()
        {
            ElementEventHub.GetElementInstance($"LNInput_{IdentityKey}")
                .Bind(this
                ,nameof(HandleOnFocus)
                ,nameof(HandleOnBlur)
                ,nameof(HandleKeyPress)
                ,nameof(HandleOnChange)
                ); 
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
                    _classHelper.AddCustomClass(_staticLGClassName).Build();
                    break;
                case InputSize.Small:
                    _classHelper.AddCustomClass(_staticSMClassName).Build();
                    break;
                case InputSize.Default:
                default:
                    break;
            }
            _wrapperClassName = _classHelper.Build();
        }

        private void HandleInputSize()
        {
            switch (Size)
            {
                case InputSize.Large:
                    _inputClassHelper.AddCustomClass(_staticLGClassName);
                    break;
                case InputSize.Small:
                    _inputClassHelper.AddCustomClass(_staticSMClassName);
                    break;
                case InputSize.Default:
                default:
                    break;
            }
        }


        private void HandleDisabled()
        {
            _inputClassHelper.AddOrRemove(_staticDisableClassName, () => Disabled);
            _wrapperClassName = _classHelper.AddOrRemove(_staticWrapperDisabledClassName, () => Disabled).Build();
        }

    }
}
