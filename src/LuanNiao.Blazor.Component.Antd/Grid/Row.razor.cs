using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;

namespace LuanNiao.Blazor.Component.Antd.Grid
{
    public partial class Row : LNBCBase
    {
        [Parameter]
        public JustifyType? Justify
        {
            get; set;
        }
        [Parameter]
        public AlignType? Align
        {
            get;
            set;
        }



        [Parameter]
        public IGutter Gutter
        {
            get;
            set;
        }


        protected async override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

                var _initialSize = await WindowInfo.GetWindowSize();

                if (Gutter is ResponsiveGutter adapt && adapt.TryGetGutter(_initialSize.InnerWidth, out var newGutter))
                {
                    this._styleHelper.Rest();
                    this._styleHelper.AddCustomStyleStr($"margin-left: -{newGutter}px");
                    this._styleHelper.AddCustomStyleStr($"margin-right: -{newGutter}px");
                    this.GutterChange?.Invoke(newGutter);
                    Flush();
                }
            }
            base.OnAfterRender(firstRender);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleGutter();
            HandleAlign();
            HandleJustify();
        }

        private void HandleJustify()
        {
            if (Justify == null)
            {
                return;
            }
            switch (Justify.Value)
            {
                case JustifyType.Start:
                    _classHelper.AddCustomClass("ant-row-start");
                    break;
                case JustifyType.End:
                    _classHelper.AddCustomClass("ant-row-end");
                    break;
                case JustifyType.Center:
                    _classHelper.AddCustomClass("ant-row-center");
                    break;
                case JustifyType.SpaceAround:
                    _classHelper.AddCustomClass("ant-row-space-around");
                    break;
                case JustifyType.SpaceBetween:
                    _classHelper.AddCustomClass("ant-row-space-between");
                    break;
                default:
                    break;
            }
        }

        private void HandleAlign()
        {
            if (Align == null)
            {
                return;
            }
            switch (Align.Value)
            {
                case AlignType.Top:
                    _classHelper.AddCustomClass("ant-row-top");
                    break;
                case AlignType.Middle:
                    _classHelper.AddCustomClass("ant-row-middle");
                    break;
                case AlignType.Bottom:
                    _classHelper.AddCustomClass("ant-row-bottom");
                    break;
                default:
                    break;
            }
        }

        private void HandleGutter()
        {
            if (Gutter == null)
            {
                return;
            }
            if (Gutter is SameGutter sameGutter && sameGutter.Gutter != 0)
            {
                var gutter = sameGutter.Gutter / 2;
                this._styleHelper.AddCustomStyleStr($"margin-left: -{gutter}px");
                this._styleHelper.AddCustomStyleStr($"margin-right: -{gutter}px");
            }
            else if (Gutter is ResponsiveGutter adapt)
            {
                adapt.Marshal();
                WindowEventHub.Resized += OnResized;
            }
            else if (Gutter is MarginGutter margin)
            {
                var horizontalSize = margin.Horizontal / 2;
                var vertialSize = margin.Vertial / 2;
                this._styleHelper.AddCustomStyleStr($"margin: -{vertialSize}px -{horizontalSize}px {vertialSize}px;");
            }
        }

        protected override void Dispose(bool flag)
        {
            WindowEventHub.Resized -= OnResized;
            base.Dispose(flag);
        }

        private void OnResized(WindowSize data)
        {
            if ((Gutter as ResponsiveGutter).TryGetGutter(data.InnerWidth, out var newGutter))
            {
                this._styleHelper.Rest();
                this._styleHelper.AddCustomStyleStr($"margin-left: -{newGutter}px");
                this._styleHelper.AddCustomStyleStr($"margin-right: -{newGutter}px");
                this.GutterChange?.Invoke(newGutter);
                Flush();
            }
        }


        public Row()
        {
            _classHelper.SetStaticClass("ant-row");
        }

        public event Action<int> GutterChange;
    }
}
