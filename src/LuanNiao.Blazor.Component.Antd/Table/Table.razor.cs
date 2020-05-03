using LuanNiao.Blazor.Component.Antd.Spin;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class Table
    {
        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Rows { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:添加只读修饰符", Justification = "<挂起>")]
        private LNSpin _spin;

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (true)
            {
                HandleLoading();
            }
        }

        private void HandleLoading()
        {
          
        }
    }
}
