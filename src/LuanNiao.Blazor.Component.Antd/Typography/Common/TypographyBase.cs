using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Core;


namespace LuanNiao.Blazor.Component.Antd.Typography.Common
{
    public abstract class TypographyBase : LNBCBase
    {
        public enum TypographyMode
        {
            None ,
            Secondary,
            Warning,
            Danger
        }
        [Parameter]
        public bool Delete { get; set; }
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Mark { get; set; }
        [Parameter]
        public bool Code { get; set; }
        [Parameter]
        public bool Underline { get; set; }
        [Parameter]
        public bool Strong { get; set; }
        [Parameter]
        public TypographyMode Type { get; set; }
        [Parameter]
        public UnionType<bool, TypographyUnion> Copyable { get; set; }
        [Parameter]
        public UnionType<bool, TypographyUnion> Editable { get; set; }
        [Parameter]
        public UnionType<bool, TypographyUnion> Ellipsis { get; set; }
        public TypographyBase()
        {
            _classHelper.SetStaticClass("ant-typography");
        }
    }
    public class TypographyUnion {
        public string Text { get; set; }
        public Action<string> Action { get; set; }
    }

}
