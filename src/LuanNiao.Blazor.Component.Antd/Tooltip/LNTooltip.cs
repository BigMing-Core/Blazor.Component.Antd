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
            var spanElementInfo = await ElementInfo.GetElementRectsByID($"main_{IdentityKey}");
            _overlayClass.RemoveCustomClass("ant-tooltip-hidden");
            _overlayStyle.AddCustomStyle("opacity", "0");
            this.Flush();
            var hideDivElementInfo = await ElementInfo.GetElementRectsByID($"hidediv_{IdentityKey}");
            var left = 0d;
            var top = 0d;



            switch (Placement)
            {
                case PlacementType.Top:
                    left = spanElementInfo.X - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = spanElementInfo.OffetTop - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;
                case PlacementType.TopLeft:
                    left = spanElementInfo.X;
                    top = spanElementInfo.OffetTop - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;
                case PlacementType.TopRight:
                    left = spanElementInfo.Right - hideDivElementInfo.Width;
                    top = spanElementInfo.OffetTop - spanElementInfo.Height - _toolTopArrowFixSize;
                    break;

                case PlacementType.Left:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.OffetTop;
                    break;
                case PlacementType.LeftTop:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.OffetTop;
                    break;
                case PlacementType.LeftBottom:
                    left = spanElementInfo.Left - hideDivElementInfo.Width;
                    top = spanElementInfo.OffetTop;
                    break;

                case PlacementType.Right:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.OffetTop;
                    break;
                case PlacementType.RightTop:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.OffetTop;
                    break;
                case PlacementType.RightBottom:
                    left = spanElementInfo.Right;
                    top = spanElementInfo.OffetTop;
                    break;

                case PlacementType.Bottom:
                    left = spanElementInfo.X - Math.Abs(spanElementInfo.Width - hideDivElementInfo.Width) / 2;
                    top = spanElementInfo.OffetTop + spanElementInfo.OffsetHeight;
                    break;
                case PlacementType.BottomLeft:
                    left = spanElementInfo.X;
                    top = spanElementInfo.OffetTop + spanElementInfo.OffsetHeight;
                    break;
                case PlacementType.BottomRight:
                    left = spanElementInfo.Right - hideDivElementInfo.Width;
                    top = spanElementInfo.OffetTop + spanElementInfo.OffsetHeight;
                    break;
            }

            _overlayStyle.AddCustomStyle("left", $"{left}px").AddCustomStyle("top", $"{top}px").RemoveCustomStyle("opacity");
            this.Flush();
        }

        [JSInvokable]
        public async void OnMouseOut()
        {
            _visibled = false;
            _overlayClass.AddCustomClass("ant-tooltip-hidden");
            this.Flush();
        }


        private void BindMouseEvent()
        {
            ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(OnMouseOver), this);
            ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            //if (this.Trigger == TriggerType.Click)
            //{
            //    ElementInfo.BindClickEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
            //}
            //else if (this.Trigger == TriggerType.Hover)
            //{
            //    ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
            //    ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            //}
            //else if (this.Trigger == TriggerType.ContextMenu)
            //{
            //    ElementInfo.BindContextMenuEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this, true);
            //    ElementInfo.BindClickEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            //}
        }
    }
}
