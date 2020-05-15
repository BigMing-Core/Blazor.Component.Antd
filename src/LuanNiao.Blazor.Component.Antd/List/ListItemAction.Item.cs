using System;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LuanNiao.Blazor.Component.Antd.List
{
    [Obsolete("In order to unify the naming rules, it is not recommended to use for the time being; Please use ListItemActionItem instead;")]
    public partial class ListItemAction
    {
        public class Item : ComponentBase
        {
            [Parameter]
            public RenderFragment ChildContent { get; set; }

            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.OpenElement(1, "<li>");
                builder.AddContent(2, ChildContent);
                builder.CloseElement();
                base.BuildRenderTree(builder);
            }
        }
    }
}
