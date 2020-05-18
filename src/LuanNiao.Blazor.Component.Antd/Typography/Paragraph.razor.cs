using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        private bool _showOkBtn = false;
        private bool _isClick = false;

        [Parameter]
        public bool Editable { get; set; }

        [Parameter]
        public string ChildText { get; set; }
        //[Parameter]
        //public UnionType<bool, TypographyUnion> Ellipsis { get; set; }
        [Parameter]
        public RenderFragment Icon { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            //HandleCopy();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindingMouseEvent();
            }
        }



        private void BindingMouseEvent()
        {
            ElementEventHub.GetElementInstance($"LNParagraph_copyImage{IdentityKey}")
                .Bind(this
                , nameof(HandleCopy));
            ElementEventHub.GetElementInstance($"paragraph_{IdentityKey}")
                .Bind(this
                , nameof(HandleClick)); 
        }

        [OnClickEvent]
        public async void HandleCopy()
        {
            if (!string.IsNullOrWhiteSpace(CustomText))
            {
                await Navigator.Copy(CustomText);
            }
            else
            {
                var text = await ElementInfo.GetElementInnerText($"paragraph_{IdentityKey}");

                await Navigator.Copy(text);
            }
            _showOkBtn = true;
            this.Flush();
            await Task.Run(async () =>
             {
                 await Task.Delay(1000*3);
                 _showOkBtn = false;
                 this.Flush();
             });
        }

        [OnClickEvent]
        public async void HandleClick()
        {
            if (!Editable) { return; }
            _isClick = true;
            this.Flush();
        }
    }
    public class TypographyUnion
    {
        public string Text { get; set; }
        public Action<string> Action { get; set; }
    }
}
