using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.List
{
    public partial class List
    {
        // ant-list ant-list-vertical ant-list-lg ant-list-split ant-list-something-after-last-item

        private const string _basicClassName                 = "ant-list";
        private const string _splitClassName                 = "ant-list-split";
        private const string _borderedClassName              = "ant-list-bordered";
        private const string _notEmptyAfterLastItemClassName = "ant-list-something-after-last-item";
        private const string _smallClassName                 = "ant-list-sm";
        private const string _largeClassName                 = "ant-list-lg";
        private const string _gridClassName                  = "ant-list-grid";
        private const string _verticalClassName              = "ant-list-vertical";

        private const string _headerClassName                = "ant-list-header";
        private const string _footerClassName                = "ant-list-footer";

        private const string _spinLoadingClassName           = "ant-spin-nested-loading";
        private const string _spinContainerClassName         = "ant-spin-container";

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
            ItemLayoutHandler();
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

        private void ItemLayoutHandler()
        {
            _classHelper.AddOrRemove(_verticalClassName, () => ItemLayout == LNListItemLayout.Vertical);
        }

        private void NotEmptyAfterLastItemHandler()
        {
            _classHelper.AddOrRemove(_notEmptyAfterLastItemClassName, () => Footer != null);
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
