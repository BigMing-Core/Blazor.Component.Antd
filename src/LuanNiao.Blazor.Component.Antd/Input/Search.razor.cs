using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class Search
    {

        private const string _staticClassName = "ant-input-search";
        private const string _staticWrapperClassName = "ant-input-affix-wrapper";

        private string _defaultValue = "";


        [Parameter]
        public Action<string> OnSearch { get; set; }

        [Parameter]
        public RenderFragment EnterButton { get; set; }

        [Parameter]
        public InputSize Size { get; set; } = InputSize.Default;

        [Parameter]
        public string DefaultValue
        {
            get => _defaultValue;
            set
            {
                if (_hasFirstRender)
                {
                    return;
                }
                _defaultValue = value;
            }
        }
        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string Placeholder { get; set; }


        public Search()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }


    }
}
