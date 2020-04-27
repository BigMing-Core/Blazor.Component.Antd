using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class MenuItem : LNBCBase
    {
        private const string _disableClassName = "ant-menu-item-disabled";
        private const string _inGroupClassName = "ant-menu-item-only-child";
        private const string _selectedClassName = "ant-menu-item-selected";

        [Parameter]
        public bool Disabled { get; set; }

        private string _className { get; set; }

        private bool _selected = false;


        [Parameter]
        public string Key
        {
            get; set;
        }

        [Parameter]
        public string Title { get; set; }


        [CascadingParameter]
        public MenuBase RootMenuInstance { get; set; }


        [CascadingParameter]
        public ItemGroup ItemGroup { get; set; }

        [CascadingParameter]
        public SubMenu ParentSubMenu { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisable();
        }
        protected override void OnInitialized()
        {
            HandleParentStatus();
            base.OnInitialized();
            HandleInGroup();
            HandleInInlineMenu();
            HandleRootMenuType();
            RootMenuInstance.ItemSelected += GotOtherItemSelectedEvent;
            HandleCurrentKeyValue();
            GetRootDefaultKeyState();
        }

        private void HandleCurrentKeyValue()
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                Key = $"lnMenuItem{RootMenuInstance.GetMyID()}";
            }
        }

        private void HandleRootMenuType()
        {
            if (RootMenuInstance is DropdownMenu)
            {
                _classHelper.SetStaticClass("ant-dropdown-menu-item ");
            }
            else
            {
                _classHelper.SetStaticClass("ant-menu-item");
            }
        }

        private void HandleParentStatus()
        {
            this._selected = this.RootMenuInstance.SelectItems.Contains(this.Key);
            this._classHelper.AddCustomClass(_selectedClassName, () => this._selected);
        }

        private void GetRootDefaultKeyState()
        {
            this._selected = RootMenuInstance.DefaultSelectedKeys.Contains(this.Key);
            HandleSelected();
        }

        private void HandleSelected()
        {
            this._classHelper.AddCustomClass(_selectedClassName, () => this._selected);
        }

        private void HandleInInlineMenu()
        {
            if (RootMenuInstance is InlineMenu inlineMenu && !inlineMenu.Collapsed)
            {
                var depth = 1;
                GetSubDepth(ref depth, this.ParentSubMenu);
                this._styleHelper.AddCustomStyle("padding-left", $"{depth * 24}px");
            }
        }

        private void GetSubDepth(ref int depth, SubMenu parent)
        {
            if (parent == null)
            {
                return;
            }
            if (parent.ParentSubmenu != null)
            {
                GetSubDepth(ref depth, parent.ParentSubmenu);
            }
            depth += 1;
        }

        private void GotOtherItemSelectedEvent(MenuItem targetItem)
        {
            if (targetItem.Equals(this))
            {
                return;
            }
            this._classHelper.RemoveCustomClass(_selectedClassName);
            this.Flush();
        }

        private void HandleClickEvent()
        {
            if (this.Disabled)
            {
                return;
            }
            this._selected = true;
            HandleSelected();
            this.RootMenuInstance.Triggered(this);
        }

        private void HandleInGroup()
        {
            if (ItemGroup != null)
            {
                _classHelper.AddCustomClass(_inGroupClassName);
            }
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
