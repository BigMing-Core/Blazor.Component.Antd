﻿using Microsoft.AspNetCore.Components;
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



        protected override void OnInitialized()
        {
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
