using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Breadcrumb
{
    public partial class LNBreadcrumb : LuanNiao.Blazor.Core.LNBCBase
    {

        [Parameter]
        public RenderFragment Separator { get; set; }



        public LNBreadcrumb()
        {
            this._classHelper.SetStaticClass("ant-breadcrumb");
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

        }

    }
}
