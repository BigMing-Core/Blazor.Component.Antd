using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.CheckBox
{
    public partial class CheckBoxGroup
    {
        [Parameter]
        public bool Disabled { get; set; }

        //[Parameter]
        //public List<string> DefaultValue { get; set; }

        [Parameter]
        public string Name { get; set; }

        public CheckBoxGroup()
        {
            _classHelper.SetStaticClass("ant-checkbox-group");
        }
    }
}
