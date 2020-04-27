using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class LNLayout : LNBCBase
    {

        [CascadingParameter]
        public LNLayout ParentLayout { get; set; }

        public LNLayout()
        {
            _classHelper.SetStaticClass("ant-layout");
        }


        internal void HasSider()
        {
            _classHelper.AddCustomClass("ant-layout-has-sider");
            this.Flush();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
