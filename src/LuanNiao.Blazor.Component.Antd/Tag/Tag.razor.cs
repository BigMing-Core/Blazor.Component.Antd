using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Tag
{
    public enum TagColor
    {
        Magenta,
        Red,
        Volcano,
        Orange,
        Gold,
        Lime,
        Green,
        Cyan,
        Blue,
        Geekblue,
        Purple
    }

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


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleBuildInColor();
        }

        private void HandleBuildInColor()
        {
            if (BuildInColor!=null)
            {
                _classHelper.AddCustomClass($"ant-tag-{(BuildInColor.ToString().ToLower())}");
            }
        }


        private void IconClicked()
        {
            _classHelper.AddCustomClass(_tagHidenClassName);
            this.Flush();
        }
    }
}
