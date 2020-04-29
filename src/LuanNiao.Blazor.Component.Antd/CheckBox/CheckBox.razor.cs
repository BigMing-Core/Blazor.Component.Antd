using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.CheckBox
{
    public partial class CheckBox
    {
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Checked { get; set; }
        [Parameter]
        public string Value { get; set; }
        [Parameter]
        public string Name { get; set; }
        [CascadingParameter]
        public CheckBoxGroup RootGourp { get; set; }

        private const string _checkClass = "ant-checkbox-checked";
        private const string _disabledClass = "ant-checkbox-disabled";

        public CheckBox()
        {
            _classHelper.SetStaticClass("ant-checkbox");
        }
        protected override void OnParametersSet()
        {
            _classHelper.AddCustomClass(_checkClass, () => Checked)
              .AddOrRemove(_disabledClass, condition: () => Disabled);
            this.Flush();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (RootGourp != null)
            {
                SetPropWhitParent();
            }
        }
        private void SetPropWhitParent()
        {
            this.Name = RootGourp.Name;
            if (RootGourp.Disabled)
            {
                this.Disabled = RootGourp.Disabled;
            }
        }
        private void HandleClickEvent()
        {
            if (this.Disabled)
            {
                return;
            }
            Checked = !Checked;
            _classHelper.AddOrRemove(_checkClass, () => Checked);
            this.Flush();
        }
    }
}
