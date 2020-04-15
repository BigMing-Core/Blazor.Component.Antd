using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using Microsoft.JSInterop;
using LuanNiao.Blazor.Core.Common;

namespace LuanNiao.Blazor.Component.Antd.Layout
{
    public partial class Sider : LNBCBase
    {

        private readonly StyleItem _siderTriggerCollapsed = new StyleItem() { StyleName = "width", Value = "80px" };
        private readonly StyleItem _siderTriggerUncollapsed = new StyleItem() { StyleName = "width", Value = "200px" };


        private readonly StyleItem[] _siderUncollapsed = {
        new StyleItem() { StyleName = "flex", Value = "0 0 200px" },
        new StyleItem() { StyleName = "max-width", Value = "200px" },
        new StyleItem() { StyleName = "min-width", Value = "200px" },
        new StyleItem() { StyleName = "width", Value = "200px" }
        };
        private readonly StyleItem[] _siderCollapsed ={
        new StyleItem() { StyleName = "flex", Value = "0 0 80px" },
        new StyleItem() { StyleName = "max-width", Value = "80px" },
        new StyleItem() { StyleName = "min-width", Value = "80px" },
        new StyleItem() { StyleName = "width", Value = "80px" }
        };
        [Parameter]
        public BreakPoint? Breakpoint { get; set; }

        [Parameter]
        public bool Collapsed { get; set; } = false;

        [Parameter]
        public int? CollapsedWidth { get; set; } = 80;
        [Parameter]
        public bool Collapsible { get; set; }
        [Parameter]
        public bool DefaultCollapsed { get; set; }

        [Parameter]
        public bool ReverseArrow { get; set; }
        [Parameter]
        public SiderTheme Theme { get; set; } = SiderTheme.Dark;

        [CascadingParameter]
        public LNLayout ParentLayout { get; set; }


        private string _siderTriggerStyle = "";
        private readonly OriginalStyleHelper _siderTriggerStyleHelper = new OriginalStyleHelper();

        internal event Action CollapsedBtnClicked;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleParentLayout();
            HandleCollapsedState();
        }

        private void HandleCollapsedState()
        {
            _siderTriggerStyle = _siderTriggerStyleHelper.AddDiffCustomStyle(
                _siderTriggerCollapsed,
                _siderTriggerUncollapsed,
                condition: () => this.Collapsed).Build();
            this._styleHelper.AddDiffCustomStyle(
                _siderCollapsed,
                _siderUncollapsed,
                condition: () => this.Collapsed
                ).Build();
        }

        private void HandleParentLayout()
        {
            if (ParentLayout != null)
            {
                ParentLayout.HasSider();
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindMouseEvent();
            }
        }

        [JSInvokable]
        public void OnCollapsedClicked()
        {
            this.Collapsed = !this.Collapsed;
            CollapsedBtnClicked?.Invoke();
            HandleCollapsedState();
            this.Flush();
        }

        private void BindMouseEvent()
        {
            ElementInfo.BindClickEvent($"sider_trigger_{IdentityKey}", nameof(OnCollapsedClicked), this, true);
        }


        public enum SiderTheme
        {
            Dark,
            Light
        }

    }

}
