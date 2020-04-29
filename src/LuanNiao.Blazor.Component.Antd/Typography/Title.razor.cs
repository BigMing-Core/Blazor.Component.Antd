using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Typography
{
    public partial  class Title
    {
        [Parameter]
        public int Level { get; set; } = 1;
        public Title()
        {

        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
    }
}
