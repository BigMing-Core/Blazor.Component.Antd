using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public abstract class MenuBase : LNBCBase
    {
        public enum MenuMode
        {
            Vertical,
            Horizontal,
            Inline,
            VerticalLeft,
            VerticalRight
        }

        public enum MenuTheme
        {
            Light,
            Dark
        }
        public enum TriggerSubMenuActionType
        {
            Hover,
            Click
        }

        public MenuBase()
        {

            _classHelper.SetStaticClass("ant-menu ant-menu-root");
        }


        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public MenuTheme Theme { get; set; } = MenuTheme.Light;

        [Parameter]
        public Action<HorizontalMenu, Item> OnClick { get; set; }

        /// <summary>
        /// whether active first menu item when show if activeKey is not set or invalid
        /// </summary>
        [Parameter]
        public bool DefaultActiveFirst { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// whether allow multiple select
        /// </summary>
        [Parameter]
        public bool Multiple { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// 	allow selecting menu items
        /// </summary>
        [Parameter]
        public bool Selectable { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// selected keys of items
        /// </summary>
        [Parameter]
        public List<string> SelectedKeys { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// initial selected keys of items
        /// </summary>
        [Parameter]
        public string[] DefaultSelectedKeys { get; set; }
        /// <summary>
        /// 	open keys of SubMenuItem
        /// </summary>
        [Parameter]
        public List<string> OpenKeys { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// initial open keys of SubMenuItem
        /// </summary>
        [Parameter]
        public string[] DefaultOpenKeys { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// called when select a menu item
        /// </summary>
        [Parameter]
        public Action<HorizontalMenu, Item> OnSelect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// 	called when click a menu item
        /// </summary>
        [Parameter]
        public Action<SubMenu> OnOpenChange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// called when open/close sub menu
        /// </summary>
        [Parameter]
        public Action<HorizontalMenu, Item> OnDeselect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// 	which action can trigger submenu open/close
        /// </summary>
        [Parameter]
        public TriggerSubMenuActionType TriggerSubMenuAction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// animate when sub menu open or close. see rc-animate for object type.
        /// </summary>
        [Parameter]
        public Object OpenAnimation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// css transitionName when sub menu open or close
        /// </summary>
        [Parameter]
        public Object OpenTransition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// delay time to show popup sub menu. unit: s
        /// </summary>
        [Parameter]
        public int SubMenuOpenDelay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// whether to render submenu even if it is not visible
        /// </summary>
        [Parameter]
        public bool ForceSubMenuRender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Where to render the DOM node of popup menu when the mode is horizontal or vertical
        /// </summary>
        [Parameter]
        public object GetPopupContainer { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        /// <summary>
        /// Describes how the popup menus should be positioned
        /// </summary>
        [Parameter]
        public object BuiltinPlacements { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        /// <summary>
        /// Specify the menu item icon.
        /// </summary>
        [Parameter]
        public object ItemIcon { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        /// <summary>
        /// Specify the menu item icon.
        /// </summary>
        [Parameter]
        public object ExpandIcon { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

        /// <summary>
        /// 	Layout direction of menu component, it supports RTL direction too.
        /// </summary>
        [Parameter]
        public object Direction { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }



    }
}
