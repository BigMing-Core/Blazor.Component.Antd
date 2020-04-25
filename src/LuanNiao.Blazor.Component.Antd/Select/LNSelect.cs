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

        private void HandleShowArrow()
        {
            _classHelper.AddOrRemove("ant-select-show-arrow", condition: () => ShowArrow);
        }
    }
}
