using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core; 

namespace LuanNiao.Blazor.Component.Antd.Grid
{
    public partial class Col : LNBCBase
    {
        [CascadingParameter]
        public Row DirectionRow
        {
            set
            {
                if (value is Row row)
                {
                    if (row.Gutter is SameGutter sameGutter && sameGutter.Gutter != 0)
                    {
                        var gutter = sameGutter.Gutter / 2;
                        this._styleHelper.AddCustomStyleStr($"padding-left: {gutter}px");
                        this._styleHelper.AddCustomStyleStr($"padding-right: {gutter}px");
                    }
                    else if (row.Gutter is ResponsiveGutter adapt)
                    {
                        row.GutterChange += (newGutter) =>
                        {
                            this._styleHelper.Rest();
                            this._styleHelper.AddCustomStyleStr($"padding-left: {newGutter}px");
                            this._styleHelper.AddCustomStyleStr($"padding-right: {newGutter}px");
                            Flush();
                        };
                    }
                    else if (row.Gutter is MarginGutter margin)
                    {
                        var horizontalSize = margin.Horizontal / 2;
                        var vertialSize = margin.Vertial / 2;
                        this._styleHelper.AddCustomStyleStr($"padding: {horizontalSize}px {vertialSize}px ");
                    }
                }
            }
        }


        public Col()
        {
            _classHelper.SetStaticClass("ant-col");
        }

        [Parameter]
        public int? Span { get; set; }
        [Parameter]
        public int? Pull { get; set; }
        [Parameter]
        public int? Push { get; set; }
        [Parameter]
        public int? Order { get; set; }
        [Parameter]
        public int? Offset { get; set; }

        [Parameter]
        public ColResponsive? XS { get; set; }
        [Parameter]
        public ColResponsive? SM { get; set; }
        [Parameter]
        public ColResponsive? MD { get; set; }
        [Parameter]
        public ColResponsive? LG { get; set; }
        [Parameter]
        public ColResponsive? XL { get; set; }
        [Parameter]
        public ColResponsive? XXL { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Span != null)
            {
                _classHelper.AddCustomClass($"ant-col-{Span.Value}");
            }
            if (Offset != null)
            {
                _classHelper.AddCustomClass($"ant-col-offet-{Span.Value}");
            }
            if (Pull != null)
            {
                _classHelper.AddCustomClass($"ant-col-pull-{Span.Value}");
            }
            if (Push != null)
            {
                _classHelper.AddCustomClass($"ant-col-push-{Span.Value}");
            }
            if (Order != null)
            {
                _classHelper.AddCustomClass($"ant-col-order-{Span.Value}");
            }
            XS?.WeaveTo(_classHelper, "ant-col-xs-{0}");
            SM?.WeaveTo(_classHelper, "ant-col-sm-{0}");
            MD?.WeaveTo(_classHelper, "ant-col-md-{0}");
            LG?.WeaveTo(_classHelper, "ant-col-lg-{0}");
            XL?.WeaveTo(_classHelper, "ant-col-xl-{0}");
            XXL?.WeaveTo(_classHelper, "ant-col-xxl-{0}");
        }



    }

    public struct ColResponsive
    {
        public int? Span { get; set; }
        public int? Pull { get; set; }
        public int? Push { get; set; }
        public int? Offset { get; set; }
        public int? Order { get; set; }


        public void WeaveTo(ClassNameHelper helper, string template)
        {
            if (helper == null)
            {
                return;
            }
            helper.AddCustomClass(Span != null ? string.Format(template, Span.Value) : "");
            helper.AddCustomClass(Offset != null ? string.Format(template, $"offset-{Offset.Value}") : "");
            helper.AddCustomClass(Order != null ? string.Format(template, $"order-{Order.Value}") : "");
            helper.AddCustomClass(Push != null ? string.Format(template, $"push-{Push.Value}") : "");
            helper.AddCustomClass(Pull != null ? string.Format(template, $"pull-{Pull.Value}") : "");
        }
    }
}
