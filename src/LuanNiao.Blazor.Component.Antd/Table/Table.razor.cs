using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class Table
    {
        [Parameter]
        public IReadOnlyList<ColumnItem> ColumnItems { get; set; }
    }
}
