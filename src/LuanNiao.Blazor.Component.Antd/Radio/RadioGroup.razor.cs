using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public partial class RadioGroup
    {
        [Parameter]
        public bool Disabled { get; set; }

        public RadioGroup()
        {
            _classHelper.SetStaticClass("ant-radio-group");
        }
        protected override void OnParametersSet()
        {
            this.Flush();
        }
    }
}
