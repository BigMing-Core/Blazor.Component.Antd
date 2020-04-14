using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public partial class LNRadioGroup
    {
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Checked { get; set; }

        private const string _checkClass = "ant-radio-checked";
        private const string _disabledClass = "ant-radio-disabled";

        public LNRadioGroup()
        {
            _classHelper.SetStaticClass("ant-radio-group");
        }
    }
}
