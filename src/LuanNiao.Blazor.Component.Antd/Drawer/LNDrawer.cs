using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Drawer
{
    public partial class LNDrawer
    {

        private const string _staticClassName = "ant-drawer";
        private const string _rightClassName = "ant-drawer-right";
        private const string _leftClassName = "ant-drawer-left";
        private const string _topClassName = "ant-drawer-top";
        private const string _bottomClassName = "ant-drawer-bottom";
        private const string _openClassName = "ant-drawer-open";

        private const string _contentWrapperHideTemplate = "{0}: {1}px; transform: translateX({2}%);";
        private const string _contentWrapperOpenTemplate = "{0}: {1}px;";

        private const string _noTitleClassName = "ant-drawer-header-no-title";
        private const string _withTitleClassName = "ant-drawer-header";

        private const string _renderInContainerStyle = "height: 100%;position: relative;";


        private string _contentWrapperStyle = "";

        private bool _openState = false;


        [Parameter]
        public bool RenderToCurrentContainer { get; set; } = false;

        [Parameter]
        public UInt16 Width { get; set; } = 256;
        [Parameter]
        public UInt16 Height { get; set; } = 256;
        [Parameter]
        public bool MaskClosable { get; set; } = true;

        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public PlacementType Placement { get; set; } = PlacementType.Right;

        [Parameter]
        public bool Closable { get; set; } = true;



        public LNDrawer()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandlePositionMainClass();
            HandleContentWrapperStyle();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindMouseEvent();
            }
        }


        public void BindMouseEvent()
        {
            if (MaskClosable)
            {
                ElementInfo.BindClickEvent($"mask_{IdentityKey}", nameof(OnMaskClick), this, true);
            }
            if (Closable)
            {
                ElementInfo.BindClickEvent($"closebtn_{IdentityKey}", nameof(OnCloseBtnClick), this, true);
            }
        }

        [JSInvokable]
        public void OnCloseBtnClick()
        {
            if (_openState)
            {
                _openState = false;
                _classHelper.RemoveCustomClass(_openClassName);
                HandleContentWrapperStyle();
                this.Flush();
            }
        }

        [JSInvokable]
        public void OnMaskClick()
        {
            if (_openState)
            {
                _openState = false;
                _classHelper.RemoveCustomClass(_openClassName);
                HandleContentWrapperStyle();
                this.Flush();
            }
        }

        public void TakeInverseOpenStatus()
        {
            _openState = !_openState;
            _classHelper.TakeInverse(_openClassName);
            HandleContentWrapperStyle();
            this.Flush();
        }


        private void HandleContentWrapperStyle()
        {
            switch (Placement)
            {
                case PlacementType.Top:
                case PlacementType.TopLeft:
                case PlacementType.TopRight:
                case PlacementType.Bottom:
                case PlacementType.BottomLeft:
                case PlacementType.BottomRight:

                    if (_openState)
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperOpenTemplate, "height", Height);
                    }
                    else
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperHideTemplate, "height", Height, -100);
                    }
                    break;
                case PlacementType.Left:
                case PlacementType.LeftTop:
                case PlacementType.LeftBottom:
                    if (_openState)
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperOpenTemplate,"width", Width);
                    }
                    else
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperHideTemplate, "width", Width, -100);
                    }
                    break;
                case PlacementType.RightTop:
                case PlacementType.Right:
                case PlacementType.RightBottom:
                    if (_openState)
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperOpenTemplate, "width", Width);
                    }
                    else
                    {
                        _contentWrapperStyle = string.Format(_contentWrapperHideTemplate, "width", Width, 100);
                    }
                    break;
            }
        }



        private void HandlePositionMainClass()
        {
            switch (Placement)
            {
                case PlacementType.Top:
                case PlacementType.TopLeft:
                case PlacementType.TopRight:
                    _classHelper.AddCustomClass(_topClassName);
                    break;
                case PlacementType.Bottom:
                case PlacementType.BottomLeft:
                case PlacementType.BottomRight:
                    _classHelper.AddCustomClass(_bottomClassName);
                    break;
                case PlacementType.Left:
                case PlacementType.LeftTop:
                case PlacementType.LeftBottom:
                    _classHelper.AddCustomClass(_leftClassName);
                    break;
                case PlacementType.RightTop:
                case PlacementType.Right:
                case PlacementType.RightBottom:
                    _classHelper.AddCustomClass(_rightClassName);
                    break;
            }
        }

    }
}
