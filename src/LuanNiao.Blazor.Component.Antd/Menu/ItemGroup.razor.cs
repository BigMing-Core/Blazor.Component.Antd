using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class ItemGroup
    { 

        [Parameter]
        public RenderFragment Title { get; set; }
    }
}
