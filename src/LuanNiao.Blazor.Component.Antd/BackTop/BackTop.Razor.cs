using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.BackTop
{
    public partial class BackTop
    {
        private const string _basicClassName = "ant-back-top";

        /// <summary>
        /// 滚动高度达到此值才出现BackTop，默认400
        /// </summary>
        [Parameter]
        public int VisibilityHeight { get; set; } = 400;

        /// <summary>
        /// 要监听元素的值，可能是dom类型或dom的id
        /// </summary>
        [Parameter]
        public string Target { get; set; } = "window";

        private string _childClassName;

        private bool _visiable { get; set; }

        public BackTop()
        {
            _classHelper.SetStaticClass(_basicClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            WindowEventHub.Scrolled += WindowEventHub_Scrolled;
            _styleHelper.AddCustomStyle("visibility", "hidden");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        private void HandleVisibily(bool visiable)
        {
            if (visiable == _visiable) return;

            _styleHelper.AddOrUpdateDiffCustomStyle(
                new StyleItem { StyleName = "visibility", Value = "visible" },
                new StyleItem { StyleName = "visibility", Value = "hidden" },
                () => visiable
            );

            _childClassName = visiable ? "fade-enter fade-enter-active" : "fade-leave fade-leave-active";
            Flush();

            _visiable = visiable;
        }

        private void WindowEventHub_Scrolled(WindowScrollEvent e)
        {
            var visiable = e.PageYOffset > VisibilityHeight;
            HandleVisibily(visiable);
        }

        protected override void Dispose(bool flag)
        {
            WindowEventHub.Scrolled -= WindowEventHub_Scrolled;
            base.Dispose(flag);
        }
    }
}
