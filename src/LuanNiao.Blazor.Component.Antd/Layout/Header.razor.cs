using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class Header:LNBCBase
    { 
        public Header()
        {
            _classHelper.SetStaticClass("ant-layout-header");
        }


        protected override void OnInitialized()
        {
            base.OnInitialized(); 
        }
    }
}
