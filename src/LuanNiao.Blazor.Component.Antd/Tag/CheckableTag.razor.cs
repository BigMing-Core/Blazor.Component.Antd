using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Tag
{
    public partial class CheckableTag
    {
        private const string _tagStaticClassName = "ant-tag";
        private const string _tagHidenClassName = "ant-tag-hidden";
        private const string _checkableClassName = "ant-tag-checkable";
        private const string _checkableCheckedClassName = "ant-tag-checkable-checked";

        public CheckableTag()
        {
            _classHelper.SetStaticClass(_tagStaticClassName);
        }


        [Parameter]
        public RenderFragment Icon { get; set; }
         

        [Parameter]
        public TagColor? BuildInColor { get; set; } = null;

        [Parameter]
        public string CustomColor { get; set; } = null;


        [Parameter]
        public bool Checked { get; set; }



        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleColor();
            HandleCheckable();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleChecked();
        }


        private void HandleChecked()
        { 
            _classHelper.AddOrRemove(_checkableCheckedClassName,()=> Checked);
        }

        private void HandleCheckable()
        {
            _classHelper.AddCustomClass(_checkableClassName);
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

        private void TagClicked()
        {
            Console.WriteLine(nameof(TagClicked));
            Checked = !Checked;
            HandleChecked();
            
        }
    }
}
