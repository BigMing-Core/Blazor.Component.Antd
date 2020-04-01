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
      


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleTheme();
            HandleMode();
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

        private void HandleMode()
        {
            //switch (Mode)
            //{
            //    case MenuMode.Vertical:
            //        _classHelper.AddCustomClass($"ant-menu-vertical");
            //        break;
            //    case MenuMode.Horizontal:
            //        _classHelper.AddCustomClass($"ant-menu-horizontal");
            //        break;
            //    case MenuMode.Inline:
            //        _classHelper.AddCustomClass($"ant-menu-inline");
            //        break;
            //    case MenuMode.VerticalLeft:
            //        _classHelper.AddCustomClass($"ant-menu-vertical-left");
            //        break;
            //    case MenuMode.VerticalRight:
            //        _classHelper.AddCustomClass($"ant-menu-vertical-right");
            //        break;
            //    default:
            //        break;
            //}
        }

    }
}
