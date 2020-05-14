using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Switch
{
    public partial class Switch
    {
        private const string _defaultClass = "ant-switch";
        private const string _checkClass = "ant-switch-checked";
        private const string _disabledClass = "ant-switch-disabled";
        private const string _smallClass = "ant-switch-small";
        private const string _loadingClass = "ant-switch-loading";

        [Parameter]
        public bool Checked { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public string Size { get; set; }
        [Parameter]
        public UnionType<string, RenderFragment> CheckedChildren { get; set; }
        [Parameter]
        public UnionType<string, RenderFragment> UnCheckedChildren { get; set; }
        public UnionType<string, RenderFragment> CheckedValue { get; set; }
        [Parameter]
        public bool Loading { get; set; }

        public Switch()
        {
            _classHelper.SetStaticClass(_defaultClass);
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleCheck();
            HandleSize();
            HandleChildren();
            HandleLoading();
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
                BindEvent();
            }
        }
        private void BindEvent()
        {
            ElementInfo.BindClickEvent($"Swtich_{IdentityKey}", nameof(HandleOnClick), this);
         
        }
        [JSInvokable]
        public async void HandleOnClick()
        {
            if (this.Disabled) { return; }
            Checked = !Checked;
            HandleCheck();
            HandleChildren();
            this.Flush();
        }
        private void HandleDisabled()
        {
            _classHelper.AddOrRemove(_disabledClass, condition: () => Disabled);
        }
        private void HandleCheck()
        {
            _classHelper.AddOrRemove(_checkClass, condition: () => Checked);
        }
        private void HandleSize() { 
            _classHelper.AddOrRemove(_smallClass, condition: () => Size=="small");
        }
        private void HandleLoading()
        {
            _classHelper.AddOrRemove(_loadingClass, condition: () => Loading);
        }
        private void HandleChildren()
        {
            CheckedValue = Checked ? CheckedChildren : UnCheckedChildren;
        }

    }
}
