using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class LNInput
    {

        private const string _staticClassName = "ant-input";
        private const string _disabledClassName = "ant-input-disabled";


        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        public LNInput()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
            this.Flush();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleDisabled();
        }

        private void HandleDisabled()
        {
            _classHelper.AddOrRemove(_disabledClassName, () => Disabled);
        }
    }
}
