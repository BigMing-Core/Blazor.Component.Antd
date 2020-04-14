using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public partial class LNRadio
    {
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Checked { get; set; }

        private const string _checkClass = "ant-radio-checked";
        private const string _disabledClass = "ant-radio-disabled";

        public LNRadio()
        {
            _classHelper.SetStaticClass("ant-radio");
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
        }
       
        private void HandleClickEvent()
        {
            if (Disabled) {
                return;
            }
            Checked = !Checked;
            _classHelper.AddOrRemove(_checkClass, ()=> Checked); 
           this.Flush();
        }


    }
}
