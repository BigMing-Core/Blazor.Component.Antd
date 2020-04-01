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
        public Item()
        {
            _classHelper.SetStaticClass("ant-menu-item");
        }
   
        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public string Title { get; set; }

    }
}
