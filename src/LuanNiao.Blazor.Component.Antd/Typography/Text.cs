using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
namespace LuanNiao.Blazor.Component.Antd.Typography
{
    public partial class Text
    {
    
        public Text()
        {
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleClass();
        }
        public void HandleClass(){
            _classHelper.AddCustomClass("ant-typography-warning", () => this.Type == TypographyMode.Warning)
                .AddCustomClass("ant-typography-secondary", () => this.Type == TypographyMode.Secondary)
                .AddCustomClass("ant-typography-danger", () => this.Type == TypographyMode.Danger)
                .AddCustomClass("ant-typography-disabled", () => this.Disabled);
        }
    }
}
