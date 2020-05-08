using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.List
{
    public partial class List
    {
        // ant-list ant-list-split ant-list-bordered ant-list-something-after-last-item

        private const string _basicClassName                 = "ant-list";
        private const string _splitClassName                 = "ant-list-split";
        private const string _borderedClassName              = "ant-list-bordered";
        private const string _notEmptyAfterLastItemClassName = "ant-list-something-after-last-item";
        private const string _smallClassName                 = "ant-list-sm";
        private const string _largeClassName                 = "ant-list-lg";
        private const string _gridClassName                  = "ant-list-grid";
                                                             
        private const string _spinLoadingClassName           = "ant-spin-nested-loading";
        private const string _spinContainerClassName         = "ant-spin-container";
                                                             
        private const string _ulClassName                    = "ant-list-items";
        private const string _liClassName                    = "ant-list-item";
                                                             
        private const string _listItemMeta                   = "ant-list-item-meta";
        private const string _listItemAvatar                 = "ant-list-item-meta-avatar";
        private const string _listItemMetaContent            = "ant-list-item-meta-content";
        private const string _listItemMetaTitle              = "ant-list-item-meta-title";
        private const string _listItemMetaDescription        = "ant-list-item-meta-description";

        [Parameter]
        public RenderFragment Header { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public RenderFragment Items { get; set; }

        /// <summary>
        /// Whether to have a border
        /// </summary>
        [Parameter] 
        public bool Bordered { get; set; } = true;

        /// <summary>
        /// Whether to have dividing line
        /// </summary>
        [Parameter]
        public bool Split { get; set; } = true;

        /// <summary>
        /// Whether to display in raster
        /// </summary>
        [Parameter]
        public bool Grid { get; set; }

        [Parameter]
        public LNListItemLayout ItemLayout { get; set; } = LNListItemLayout.Horizontal;

        [Parameter]
        public LNListSize Size { get; set; } = LNListSize.Default;

        public List()
        {
            _classHelper.SetStaticClass(_basicClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            BorderHandler();
            SplitHandler();
            SizeHandler();
            NotEmptyAfterLastItemHandler();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        private void SizeHandler()
        {
            switch (Size)
            {
                case LNListSize.Large:
                    _classHelper.AddCustomClass(_largeClassName);
                    break;
                case LNListSize.Small:
                    _classHelper.AddCustomClass(_smallClassName);
                    break;
            }
        }

        private void BorderHandler()
        {
            _classHelper.AddOrRemove(_borderedClassName, () => Bordered);
        }

        private void SplitHandler()
        {
            _classHelper.AddOrRemove(_splitClassName, () => Split);
        }

        private void GridHandler()
        {
            _classHelper.AddOrRemove(_gridClassName, () => Grid);
        }

        private void NotEmptyAfterLastItemHandler()
        {
            _classHelper.AddOrRemove(_gridClassName, () => Footer == null);
        }
    }

    public enum LNListItemLayout
    {
        Horizontal,
        Vertical
    }

    public enum LNListSize
    {
        Default,
        Large,
        Small
    }
}
