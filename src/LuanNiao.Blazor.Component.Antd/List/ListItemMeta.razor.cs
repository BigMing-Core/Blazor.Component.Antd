using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.List
{
    public partial class ListItemMeta
    {
        private const string _listItemMetaClassName               = "ant-list-item-meta";
        private const string _listItemMetaContentClassName        = "ant-list-item-meta-content";
        private const string _listItemAvatarClassName             = "ant-list-item-meta-avatar";
        private const string _listItemMetaTitleClassName          = "ant-list-item-meta-title";
        private const string _listItemMetaDescriptionClassName    = "ant-list-item-meta-description";

        [Parameter]
        public RenderFragment Avatar { get; set; }

        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public RenderFragment Description { get; set; }
    }
}
