using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class HorizontalMenu : MenuBase
    {
        public HorizontalMenu()
        {
            _classHelper.AddCustomClass($"ant-menu-horizontal");
        }



        protected override void OnInitialized()
        {
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
