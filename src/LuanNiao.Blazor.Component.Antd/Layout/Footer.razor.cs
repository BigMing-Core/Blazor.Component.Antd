using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class Footer:LNBCBase
    { 

        public Footer()
        {
            _classHelper.SetStaticClass("ant-layout-footer");
        }


        protected override void OnInitialized()
        {
            base.OnInitialized(); 
        }
    }
}
