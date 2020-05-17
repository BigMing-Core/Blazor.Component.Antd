using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;

namespace LuanNiao.Blazor.Component.Antd.BackTop
{
    public partial class BackTop
    {
        private const string _basicClassName = "ant-back-top";

        private bool _isWindowEvent;

        /// <summary>
        /// 滚动高度达到此值才出现BackTop，默认400
        /// </summary>
        [Parameter]
        public int VisibilityHeight { get; set; } = 400;

        /// <summary>
        /// 要监听元素的值，可能是dom类型或dom的id
        /// </summary>
        [Parameter]
        public string Target { get; set; }

        private string _childClassName;

        private bool _visiable { get; set; }

        public BackTop()
        {
            Console.WriteLine(Target);
            _classHelper.SetStaticClass(_basicClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            _isWindowEvent = string.IsNullOrWhiteSpace(Target) || "window".Equals(Target, System.StringComparison.OrdinalIgnoreCase);
            Disposing += () =>
            {
                if (_isWindowEvent)
                {
                    WindowEventHub.Scrolled -= WindowEventHub_Scrolled;
                }
            };

            // 获取要监听的元素
            WindowEventHub.Scrolled += WindowEventHub_Scrolled;

            // 获取当前位置
            _styleHelper.AddCustomStyle("visibility", "hidden");
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender &&!_isWindowEvent)
            { 
                var target = ElementEventHub.GetElementInstance(Target.Trim());
                target.Bind(this, nameof(ElementEventHub_Scrolled));
            }
        }

        private void HandleListenDom()
        {
            if(string.IsNullOrWhiteSpace(Target) || Target.Trim().ToLower() == "window")
            {
                // 监听窗体
                _isWindowEvent = true;
                WindowEventHub.Scrolled += WindowEventHub_Scrolled;
            }
            else
            {
                // 监听dom
                _isWindowEvent = false;
            }
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
            _visiable = visiable;
            Flush();
        }

        private void WindowEventHub_Scrolled(WindowScrollEvent e)
        {
            var visiable = e.PageYOffset > VisibilityHeight;
            HandleVisibily(visiable);
        }

        [OnScrollEvent]
        public void ElementEventHub_Scrolled(ElementScrollEvent e)
        {
            var visiable = e.ScrollTop > VisibilityHeight;
            HandleVisibily(visiable);
        }
    }
}
