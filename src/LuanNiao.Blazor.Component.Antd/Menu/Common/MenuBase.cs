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

        private readonly List<string> _currentSelectItems = new List<string>();

        private int _currentMenuItemKey = 0;
         

        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public MenuTheme Theme { get; set; } = MenuTheme.Light;

        /// <summary>
        /// whether active first menu item when show if activeKey is not set or invalid
        /// </summary>
        [Parameter]
        public bool DefaultActiveFirst { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// whether allow multiple select
        /// </summary>
        [Parameter]
        public bool Multiple { get => false; set => throw new NotImplementedException(); } 
        /// <summary>
        /// selected keys of items
        /// </summary>
        [Parameter]
        public List<string> SelectItems { get => _currentSelectItems; set { } }
        /// <summary>
        /// initial selected keys of items
        /// </summary>
        [Parameter]
        public string[] DefaultSelectedKeys { get; set; } =new string[0];
        /// <summary>
        /// 	open keys of SubMenuItem
        /// </summary>
        [Parameter]
        public string[] OpenKeys { get => _currentSelectItems.ToArray(); set { } }


        /// <summary>
        /// initial open keys of SubMenuItem
        /// </summary>
        [Parameter]
        public string[] DefaultOpenKeys { get; set; } = new string[0];
        /// <summary>
        /// called when select a menu item
        /// </summary>
        [Parameter]
        public Action<MenuBase, List<string>> OnSelect { get; set; }
        /// <summary>
        /// 	called when click a menu item
        /// </summary>
        [Parameter]
        public Action<SubMenu> OnOpenChange { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /// <summary>
        /// called when open/close sub menu
        /// </summary>
        [Parameter]
        public Action<MenuBase, List<string>> OnDeselect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
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
         
  

        internal void Triggered(MenuItem sourceItem)
        {
            this.ItemSelected?.Invoke(sourceItem);
            if (this.Multiple && !this._currentSelectItems.Contains(sourceItem.Key))
            {
                this._currentSelectItems.Add(sourceItem.Key);
            }
            else
            {
                this._currentSelectItems.Clear();
                this._currentSelectItems.Add(sourceItem.Key);
            }
            this.OnSelect?.Invoke(this, this._currentSelectItems);
        }
        internal int GetMyID()
        {
            return System.Threading.Interlocked.Increment(ref _currentMenuItemKey);
        }

        

        /// <summary>
        /// there's some on selected
        /// </summary>
        internal event Action<MenuItem> ItemSelected;
    }
}
