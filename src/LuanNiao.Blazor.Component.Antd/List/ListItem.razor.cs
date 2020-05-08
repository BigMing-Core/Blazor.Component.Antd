using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.List
{
    public partial class ListItem
    {
        private const string _listItemClassName                = "ant-list-item";
        private const string _listItemMainClassName            = "ant-list-item-main";
        private const string _listItemExtraClassName           = "ant-list-item-extra";
        private const string _listItemActionClassName          = "ant-list-item-action";

        [Parameter]
        public RenderFragment Meta { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public RenderFragment Extra { get; set; }

        [Parameter]
        public RenderFragment Action { get; set; }
    }
}
