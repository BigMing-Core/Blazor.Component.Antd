using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Component.Antd.Common;

namespace LuanNiao.Blazor.Component.Antd.Grid
{
    public partial class Row : WBCBase
    {
        [Parameter]
        public Justify? Justify
        {
            get; set;
        }
        [Parameter]
        public Align? Align
        {
            get; set;
        }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }

        [Parameter]
        public IGutter Gutter
        {
            get; set;
        }

        [Inject]
        public IJSRuntime JSRT { get; set; }
        protected async override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {

                var _initialSize = await JSRT.InvokeAsync<WindowSize>("WaveBlazor.GetWindowSize");

                if (Gutter is ResponsiveGutter adapt && adapt.TryGetGutter(_initialSize.InnerSize.Width, out var newGutter))
                {
                    this._styleHelper.Rest();
                    this._styleHelper.AddCustomStyle($"margin-left: -{newGutter}px");
                    this._styleHelper.AddCustomStyle($"margin-right: -{newGutter}px");
                    this.GutterChange?.Invoke(newGutter);
                    Flush();
                }
            }
            base.OnAfterRender(firstRender);
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
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
                case Common.Justify.Start:
                    _classHelper.AddCustomClass("ant-row-start");
                    break;
                case Common.Justify.End:
                    _classHelper.AddCustomClass("ant-row-end");
                    break;
                case Common.Justify.Center:
                    _classHelper.AddCustomClass("ant-row-center");
                    break;
                case Common.Justify.SpaceAround:
                    _classHelper.AddCustomClass("ant-row-space-around");
                    break;
                case Common.Justify.SpaceBetween:
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
                case Common.Align.Top:
                    _classHelper.AddCustomClass("ant-row-top");
                    break;
                case Common.Align.Middle:
                    _classHelper.AddCustomClass("ant-row-middle");
                    break;
                case Common.Align.Bottom:
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
                this._styleHelper.AddCustomStyle($"margin-left: -{gutter}px");
                this._styleHelper.AddCustomStyle($"margin-right: -{gutter}px");
            }
            else if (Gutter is ResponsiveGutter adapt)
            {
                adapt.Marshal();


                WindowEventHub.Resized += (data) =>
                {
                    if (adapt.TryGetGutter(data.InnerSize.Width, out var newGutter))
                    {
                        this._styleHelper.Rest();
                        this._styleHelper.AddCustomStyle($"margin-left: -{newGutter}px");
                        this._styleHelper.AddCustomStyle($"margin-right: -{newGutter}px");
                        this.GutterChange?.Invoke(newGutter);
                        Flush();
                    }
                };
            }
            else if (Gutter is MarginGutter margin)
            {
                var horizontalSize = margin.Horizontal / 2;
                var vertialSize = margin.Vertial / 2;
                this._styleHelper.AddCustomStyle($"margin: -{horizontalSize}px -{vertialSize}px {horizontalSize}px;");
            }
        }


        public Row()
        {
            _classHelper.SetStaticClass("ant-row");
        }

        public event Action<int> GutterChange;

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
