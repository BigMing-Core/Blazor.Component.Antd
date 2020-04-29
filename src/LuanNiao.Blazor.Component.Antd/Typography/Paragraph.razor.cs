using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        public bool Copyable { get; set; }

        [Parameter]
        public string CustomText { get; set; } = null;

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




        private void BindingMouseEvent()
        {
            ElementInfo.BindClickEvent($"LNParagraph_copyImage{IdentityKey}", nameof(HandleCopy), this);
        }

        [JSInvokable]
        public async void HandleCopy()
        {
            if (!string.IsNullOrWhiteSpace(CustomText))
            {
                await Navigator.Copy(CustomText);
            }
            

        }
    }
    public class TypographyUnion
    {
        public string Text { get; set; }
        public Action<string> Action { get; set; }
    }
}
