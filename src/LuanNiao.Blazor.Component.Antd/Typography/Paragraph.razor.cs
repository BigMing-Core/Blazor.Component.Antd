using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Typography
{
    public partial class Paragraph
    {
        public Paragraph()
        {
        }

        [Parameter]
        public UnionType<bool, string> Copyable { get; set; }
        //[Parameter]
        //public UnionType<bool, TypographyUnion> Editable { get; set; }
        //[Parameter]
        //public UnionType<bool, TypographyUnion> Ellipsis { get; set; }
        [Parameter]
        public RenderFragment Icon { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //HandleCopy();
        }
        //private void HandleCopy() {
        //    if (this.Copyable?.Value != null) {
        //        Copyable.Switch((a) => {
        //            Console.WriteLine(a);
        //        }, (b) => {
        //            Console.WriteLine(b);

        //        });
        //    }
        //}
    }
    public class TypographyUnion
    {
        public string Text { get; set; }
        public Action<string> Action { get; set; }
    }
}
