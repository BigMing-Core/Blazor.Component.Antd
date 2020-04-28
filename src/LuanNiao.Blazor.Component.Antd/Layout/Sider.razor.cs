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
        private readonly StyleItem _siderTriggerUncollapsedFullScreen = new StyleItem() { StyleName = "width", Value = "100%" };


        private readonly StyleItem[] _siderUncollapsed = {
        new StyleItem() { StyleName = "flex", Value = "0 0 200px" },
        new StyleItem() { StyleName = "max-width", Value = "200px" },
        new StyleItem() { StyleName = "min-width", Value = "200px" },
        new StyleItem() { StyleName = "width", Value = "200px" }
        };
        private readonly StyleItem[] _siderUncollapsedFullScreen = {
        new StyleItem() { StyleName = "flex", Value = "0 0 100%" },
        new StyleItem() { StyleName = "max-width", Value = "100%" },
        new StyleItem() { StyleName = "min-width", Value = "100%" },
        new StyleItem() { StyleName = "width", Value = "100%" },
        new StyleItem() { StyleName = "z-index", Value = "10" }
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
        public bool FullScreenMode { get; set; }
        [Parameter]
        public SiderTheme Theme { get; set; } = SiderTheme.Dark;

        [CascadingParameter]
        public LNLayout ParentLayout { get; set; }


        private string _siderTriggerStyle = "";
        private readonly OriginalStyleHelper _siderTriggerStyleHelper = new OriginalStyleHelper();

        public event Action CollapsedBtnClicked;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleParentLayout();
        }



        private void HandleCollapsedState()
        {
            _siderTriggerStyle = _siderTriggerStyleHelper.AddDiffCustomStyle(
                _siderTriggerCollapsed,
                FullScreenMode ? _siderTriggerUncollapsedFullScreen : _siderTriggerUncollapsed,
                condition: () => this.Collapsed).Build();
            this._styleHelper.AddDiffCustomStyle(
                _siderCollapsed,
                FullScreenMode ? _siderUncollapsedFullScreen : _siderUncollapsed,
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

        protected async override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindMouseEvent();
                WindowEventHub.Resized += WindowEventHub_Resized;
                WindowEventHub_Resized(await WindowInfo.GetWindowSize());
                HandleCollapsedState();
                this.Flush();
            }
        }

        private void WindowEventHub_Resized(WindowSize obj)
        {            
            FullScreenMode = obj.InnerWidth <= 575;
            HandleCollapsedState();
            this.Flush();
        }

       
        [JSInvokable]
        public void InverseCollapseStatus()
        {
            this.Collapsed = !this.Collapsed;
            CollapsedBtnClicked?.Invoke();
            HandleCollapsedState();
            this.Flush();
        }

        private void BindMouseEvent()
        {
            ElementInfo.BindClickEvent($"sider_trigger_{IdentityKey}", nameof(InverseCollapseStatus), this, true);
        }


        public enum SiderTheme
        {
            Dark,
            Light
        }

    }

}
