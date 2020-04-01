using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class Item : LNBCBase
    {
        private const string _disableClassName = "ant-menu-item-disabled";
        public Item()
        {
            _classHelper.SetStaticClass("ant-menu-item");
        }
   
        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Title { get; set; }

        

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisable();
        }
        private void HandleDisable()
        {
            if (Disabled)
            {
                _classHelper.AddCustomClass(_disableClassName);
            }
            else
            {
                _classHelper.RemoveCustomClass(_disableClassName);
            }
        }
    }
}
