using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class DropdownMenu
    {

        public DropdownMenu()
        {
            _classHelper.SetStaticClass("ant-dropdown-menu  ant-dropdown-menu-root ant-dropdown-menu-vertical");
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleTheme();
        }

        private void HandleTheme()
        {
            _classHelper
                .AddCustomClass("ant-dropdown-menu-light", () => this.Theme== MenuTheme.Light)
                .AddCustomClass("ant-dropdown-menu-dark", () => this.Theme == MenuTheme.Dark);
        }
    }
}
