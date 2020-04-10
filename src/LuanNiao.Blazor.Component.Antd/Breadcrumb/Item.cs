using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Breadcrumb
{
    public partial class Item
    {
        [CascadingParameter]
        public LNBreadcrumb RootBreadcrumb { get; set; }

        [Parameter]
        public string Href { get; set; }
        public Item()
        {
            _classHelper.SetStaticClass("ant-breadcrumb-link");
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

        }
    }
}
