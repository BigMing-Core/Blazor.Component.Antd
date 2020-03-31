using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Component.Antd.Common;

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class Sider : WBCBase
    {
        [Parameter]
        public BreakPoint? Breakpoint { get; set; }

        [Parameter]
        public bool? Collapsed { get; set; }

        [Parameter]
        public int? CollapsedWidth { get; set; } = 80;
        [Parameter]
        public bool Collapsible { get; set; }
        [Parameter]
        public bool DefaultCollapsed { get; set; }

        [Parameter]
        public bool ReverseArrow { get; set; }
        [Parameter]
        public SiderTheme Theme { get; set; } = SiderTheme.Dark;


        public enum SiderTheme
        {
            Dark,
            Light
        }

    }

}
