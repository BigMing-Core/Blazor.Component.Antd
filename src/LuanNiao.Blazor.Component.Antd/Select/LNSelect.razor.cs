using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Select
{
    public partial class LNSelect
    {
        public enum SMode
        {
            Single,
            Multiple,
            Tags
        }
        private bool _showOptions = false;
        /// <summary>
        /// Whether to show the drop-down arrow
        /// </summary>
        [Parameter]
        public bool ShowArrow { get; set; } = true;
        /// <summary>
        /// Set mode of Select
        /// </summary>
        [Parameter]
        public SMode Mode { get; set; }
        public LNSelect()
        {
            _classHelper.SetStaticClass("ant-select");
        }
        protected override Task OnInitializedAsync()
        {
            HandleShowArrow();
            HandleMode();
            return base.OnInitializedAsync();
        }
        protected override Task OnParametersSetAsync()
        {
            return base.OnParametersSetAsync();
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            return base.OnAfterRenderAsync(firstRender);
        }

        protected Task OnTaggorOptions()
        {
            _classHelper.AddOrRemove("ant-select-open",condition:()=> _showOptions);

            this.Flush();
            _showOptions = true;
            return Task.CompletedTask;
        }

        private void HandleShowArrow()
        {
            _classHelper.AddOrRemove("ant-select-show-arrow", condition: () => ShowArrow);
        }
        private void HandleMode()
        {
            _classHelper.AddOrRemove("ant-select-single", condition
                : () => Mode == SMode.Single);
            _classHelper.AddOrRemove("ant-select-multiple", condition: () => Mode == SMode.Multiple || Mode == SMode.Tags);
        }


    }
}
