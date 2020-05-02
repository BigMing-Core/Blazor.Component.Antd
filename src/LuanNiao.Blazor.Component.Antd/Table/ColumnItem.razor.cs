using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class ColumnItem
    {
        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public string DataKey { get; set; }

        [Parameter]
        public Func< RenderFragment> MyProperty { get; set; }
    }
}
