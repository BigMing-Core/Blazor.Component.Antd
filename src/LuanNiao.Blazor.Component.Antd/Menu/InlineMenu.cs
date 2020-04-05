using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class InlineMenu
    {
        public InlineMenu()
        {
            _classHelper.AddCustomClass($"ant-menu-inline");
        }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleTheme();
        }

        private void HandleTheme()
        {
            switch (Theme)
            {
                case MenuTheme.Light:
                    _classHelper.AddCustomClass("ant-menu-light");
                    break;
                case MenuTheme.Dark:
                    _classHelper.AddCustomClass("ant-menu-dark");
                    break;
                default:
                    break;
            }
        }

        [Parameter]
        public List<MenuBase> SubMenu { get; set; }
    }
}
