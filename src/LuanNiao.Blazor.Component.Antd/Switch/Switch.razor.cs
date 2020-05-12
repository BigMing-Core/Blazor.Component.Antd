using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
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

        [Parameter]

        public bool Checked { get; set; }
        [Parameter]
        public UnionType<string,> CheckedChildren { get; set; }
        [Parameter]
        public bool DefaultChecked { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public string Size { get; set; }
        [Parameter]
        public int UnCheckedChildren { get; set; }
        public int CheckedValue { get; set; }
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
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
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
        private void HandleChildren()
        {

        }

    }
}
