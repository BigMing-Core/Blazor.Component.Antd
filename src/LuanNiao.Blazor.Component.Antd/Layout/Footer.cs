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
        [Parameter]
        public bool HasSilder { get; set; }


        public Footer()
        {
            _classHelper.SetStaticClass("ant-layout");
        }


        protected override void OnParametersSet()
        {
            if (HasSilder)
            {
                _classHelper.AddCustomClass("ant-layout-has-sider");
            }
            base.OnParametersSet();
        }
    }
}
