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
        private const string _inGroupClassName = "ant-menu-item-only-child";
        private const string _selectedClassName = "ant-menu-item-selected";
        public Item()
        {
            _classHelper.SetStaticClass("ant-menu-item");
        }


        [Parameter]
        public bool Disabled { get; set; }

        private string _key = null;

        [Parameter]
        public string Key
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_key))
                {
                    return IdentityKey;
                }
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        [Parameter]
        public string Title { get; set; }


        [CascadingParameter]
        public MenuBase RootMenuInstance { get; set; }


        [CascadingParameter]
        public ItemGroup ItemGroup { get; set; }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisable();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleInGroup();
            RootMenuInstance.ItemSelected += GotOtherItemSelectedEvent;
        }

        private void GotOtherItemSelectedEvent(Item targetItem)
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
            this._classHelper.AddCustomClass(_selectedClassName);
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
