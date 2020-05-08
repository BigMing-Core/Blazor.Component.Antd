using System;
using System.Collections.Generic;
using System.Text;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace LuanNiao.Blazor.Component.Antd.List
{
    public partial class ListItem
    {
        private const string _listItemClassName                = "ant-list-item";
        private const string _listItemMainClassName            = "ant-list-item-main";
        private const string _listItemExtraClassName           = "ant-list-item-extra";
        private const string _listItemActionClassName          = "ant-list-item-action";

        //[Parameter]
        //public RenderFragment MetaContent { get; set; }

        //[Parameter]
        //public RenderFragment Content { get; set; }

        //[Parameter]
        //public RenderFragment Extra { get; set; }

        //[Parameter]
        //public List<RenderFragment> Actions { get; set; }

        public class ActionItem : LNBCBase
        {
            protected override void BuildRenderTree(RenderTreeBuilder builder)
            {
                builder.OpenElement(1, "li");
                builder.AddContent(2, ChildContent);
                builder.CloseElement();
                base.BuildRenderTree(builder);
            }
        }
    }
}
