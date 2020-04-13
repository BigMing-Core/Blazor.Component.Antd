using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core; 

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class Sider : LNBCBase
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

        [CascadingParameter]
        public LNLayout ParentLayout { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleParentLayout();
        }

        private void HandleParentLayout()
        {
            if (ParentLayout != null)
            {
                ParentLayout.HasSider();
            }
        }


        public enum SiderTheme
        {
            Dark,
            Light
        }

    }

}
