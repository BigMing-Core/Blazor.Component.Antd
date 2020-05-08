using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class WeekPicker
    {

        [Parameter]
        public int CurrentMonth { get; set; }

        [Parameter]
        public int CurrentYear { get; set; }

        [Parameter]
        public int CurrentWeek { get; set; }
    }
}
