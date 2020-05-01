using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Tooltip
{
    public partial class LNTooltip
    {
        private readonly ClassNameHelper _overlayClass = new ClassNameHelper().SetStaticClass("ant-tooltip");
        private readonly OriginalStyleHelper _overlayStyle = new OriginalStyleHelper();
        private const int _toolTopArrowFixSize = 10;
        private bool _visibled = false;
        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public bool DefaultVisiable { get; set; } = true;
        [Parameter]
        public bool Visible { get; set; } = false;

        [Parameter]
        public string OverlayStyle { get { return _overlayStyle.Build(); } set { _overlayStyle.AddCustomStyleStr(value); } }

        [Parameter]
        public string OverlayClass { get { return _overlayClass.Build(); } set { _overlayClass.AddCustomClass(value); } }

        [Parameter]
        public PlacementType Placement { get; set; }
        [Parameter]
        public long MouseEnterDelayMS { get; set; }

        [Parameter]
        public long MouseLeaveDelay { get; set; }

        [Parameter]
        public bool InsideOfTarget { get; set; }

        [Inject]
        public TooltipService TooltipService { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:添加只读修饰符", Justification = "<挂起>")]
        internal RenderFragment _toolTipData;



        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandlePlacementType();
            HandleDefaultVisibleInfo();
        } 

        private void HandleDefaultVisibleInfo()
        {
            _visibled = this.DefaultVisiable;
            _overlayClass.AddCustomClass("ant-tooltip-hidden", () => this.DefaultVisiable);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                TooltipService.Show(this);
                BindMouseEvent();
            }
        }

        private void HandlePlacementType()
        {
            switch (Placement)
            {
                case PlacementType.Top:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-top");
                    break;
                case PlacementType.Left:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-left");
                    break;
                case PlacementType.Right:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-right");
                    break;
                case PlacementType.Bottom:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-bottom");
                    break;
                case PlacementType.TopLeft:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-topLeft");
                    break;
                case PlacementType.TopRight:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-topRight");
                    break;
                case PlacementType.BottomLeft:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-bottomLeft");
                    break;
                case PlacementType.BottomRight:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-bottomRight");
                    break;
                case PlacementType.LeftTop:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-leftTop");
                    break;
                case PlacementType.LeftBottom:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-leftBottom");
                    break;
                case PlacementType.RightTop:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-rightTop");
                    break;
                case PlacementType.RightBottom:
                    _overlayClass.AddCustomClass("ant-tooltip-placement-rightBottom");
                    break;
            }
        }
        [JSInvokable]
        public async void OnMouseOver()
        {
            _visibled = true;
            _overlayClass.RemoveCustomClass("ant-tooltip-hidden");
            _overlayStyle.AddCustomStyle("opacity", "0");
            this.Flush();
            var left = 0d;
            var top = 0d;

            var spanElementInfo = await ElementInfo.GetElementRectsByID($"main_{IdentityKey}");
            var hideDivElementInfo = await ElementInfo.GetElementRectsByID($"hidediv_{IdentityKey}");

            if (InsideOfTarget)
            {
                InsideOfTargetCals(ref left, ref top, spanElementInfo, hideDivElementInfo);
            }
            else
            {
                NormalCalc(ref left, ref top, spanElementInfo, hideDivElementInfo);
            }

            _overlayStyle
                .AddCustomStyle("left", $"{left}px")
                .AddCustomStyle("top", $"{top}px")
                .AddCustomStyle("position", $"fixed")
                .RemoveCustomStyle("opacity");
            this.Flush();
            TooltipService.NeedFlush();
        }

        [JSInvokable]
        public void OnMouseOut()
        {
            _visibled = false;
            _overlayClass.AddCustomClass("ant-tooltip-hidden");
            this.Flush();
            TooltipService.NeedFlush();
        }

        private void InsideOfTargetCals(ref double left, ref double top, ElementRects spanElementInfo, ElementRects hideDivElementInfo)
        {
            switch (Placement)
            {
                case PlacementType.Top:
                case PlacementType.TopLeft:
                case PlacementType.TopRight:
                    left = 0 - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = spanElementInfo.Top - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;

                case PlacementType.Left:
                case PlacementType.LeftTop:
                case PlacementType.LeftBottom:
                    left = 0 - hideDivElementInfo.Width;
                    top = spanElementInfo.OffsetTop - Math.Abs(spanElementInfo.Height - hideDivElementInfo.Height) / 2;
                    break;

                case PlacementType.Right:
                case PlacementType.RightTop:
                case PlacementType.RightBottom:
                    left = 0 + Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = spanElementInfo.OffsetTop - Math.Abs(spanElementInfo.Height - hideDivElementInfo.Height) / 2;
                    break;

                case PlacementType.Bottom:
                case PlacementType.BottomLeft:
                case PlacementType.BottomRight:
                    left = 0 - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = 0 + spanElementInfo.Height;
                    break;
            }
        }

        private void NormalCalc(ref double left, ref double top, ElementRects spanElementInfo, ElementRects hideDivElementInfo)
        {

            switch (Placement)
            {
                case PlacementType.Top:
                    left = spanElementInfo.X - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 4;
                    top = spanElementInfo.Top - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;
                case PlacementType.TopLeft:
                    left = spanElementInfo.X;
                    top = spanElementInfo.Top - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;
                case PlacementType.TopRight:
                    left = spanElementInfo.Right - hideDivElementInfo.Width;
                    top = spanElementInfo.Top - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;

                case PlacementType.Left:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.Top;
                    break;
                case PlacementType.LeftTop:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.Top;
                    break;
                case PlacementType.LeftBottom:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.Top;
                    break;

                case PlacementType.Right:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.Top;
                    break;
                case PlacementType.RightTop:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.Top;
                    break;
                case PlacementType.RightBottom:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.Top;
                    break;

                case PlacementType.Bottom:
                    left = spanElementInfo.X - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = spanElementInfo.Top + spanElementInfo.Height;
                    break;
                case PlacementType.BottomLeft:
                    left = spanElementInfo.X;
                    top = spanElementInfo.Top + spanElementInfo.Height;
                    break;
                case PlacementType.BottomRight:
                    left = spanElementInfo.Right - hideDivElementInfo.Width;
                    top = spanElementInfo.Top + spanElementInfo.Height;
                    break;
            }
        }


        private void BindMouseEvent()
        {
            ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(OnMouseOver), this);
            ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            
        }
    }
}
