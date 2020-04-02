using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class SubMenu : LNBCBase
    {
        private const string _disableClassName = "ant-menu-item-disabled";
        public SubMenu()
        {
            _classHelper.SetStaticClass("ant-menu-submenu");
        }

        [Parameter]
        public string PopupClassName { get; set; }

        [Parameter]
        public List<MenuBase> Children { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public Action<SubMenu> OnTitleClick { get; set; }


        protected override void OnInitialized()
        {

        }
        private void HandleParent()
        {
            if (this.Parent is HorizontalMenu)
            {
                _classHelper.AddCustomClass("ant-menu-submenu-horizontal");
            }

        }

    }
}
