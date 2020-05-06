using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Tag
{
 

    public partial class Tag
    {
        private const string _tagStaticClassName = "ant-tag";
        private const string _tagHidenClassName = "ant-tag-hidden"; 

        public Tag()
        {
            _classHelper.SetStaticClass(_tagStaticClassName);
        }


        [Parameter]
        public RenderFragment Icon { get; set; }

        [Parameter]
        public bool Closeable { get; set; }

        [Parameter]
        public TagColor? BuildInColor { get; set; } = null;

        [Parameter]
        public string CustomColor { get; set; } = null;
         



        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleColor(); 
        } 

        private void HandleColor()
        {
            if (BuildInColor != null)
            {
                _classHelper.AddCustomClass($"ant-tag-{(BuildInColor.ToString().ToLower())}");
            }
            else if (!string.IsNullOrWhiteSpace(CustomColor))
            {
                _classHelper.AddCustomClass($"ant-tag-has-color");
                _styleHelper.AddCustomStyle("background-color", CustomColor);
            }
        }


        private void IconClicked()
        {
            Console.WriteLine(nameof(IconClicked));
            _classHelper.AddCustomClass(_tagHidenClassName);
            this.Flush();
        }

     
    }
}
