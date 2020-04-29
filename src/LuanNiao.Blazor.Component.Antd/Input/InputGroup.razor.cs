using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class InputGroup
    {
        [Parameter]
        public InputSize Size { get; set; } = InputSize.Default;
        [Parameter]
        public bool Compact { get; set; }

        private const string _staticClassName = "ant-input-group";
        private const string _staticLGClassName = "ant-input-group-lg";
        private const string _staticSMClassName = "ant-input-group-sm";
        private const string _staticCompactClassName = "ant-input-group-compact";

        public InputGroup()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleSize();
        }

        private void HandleSize()
        {
            _classHelper
                .AddCustomClass(_staticLGClassName, () => Size == InputSize.Large)
                .AddCustomClass(_staticSMClassName, () => Size == InputSize.Small)
                .AddCustomClass(_staticCompactClassName, () => Compact);
        }


    }
}
