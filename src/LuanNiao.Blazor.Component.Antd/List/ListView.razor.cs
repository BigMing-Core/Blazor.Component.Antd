using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
namespace LuanNiao.Blazor.Component.Antd.List
{
    [Obsolete("This class can cause performance problems; use LuanNiao.Blazor.Component.Antd.List.List instead")]
    public partial class ListView<TItem>
    {
        private const string _basicClassName = "ant-list";
        private const string _splitClassName = "ant-list-split";
        private const string _borderedClassName = "ant-list-bordered";
        private const string _notEmptyAfterLastItemClassName = "ant-list-something-after-last-item";
        private const string _smallClassName = "ant-list-sm";
        private const string _largeClassName = "ant-list-lg";
        private const string _gridClassName = "ant-list-grid";
        private const string _verticalClassName = "ant-list-vertical";

        private const string _headerClassName = "ant-list-header";
        private const string _footerClassName = "ant-list-footer";

        private const string _spinLoadingClassName = "ant-spin-nested-loading";
        private const string _spinContainerClassName = "ant-spin-container";

        private const string _listItemBasicClassName = "ant-list-item";
        private const string _noFlexClassName = "ant-list-item-no-flex";

        private string _listItemClassName = _listItemBasicClassName;

        [Parameter]
        public LNListSize Size { get; set; } = LNListSize.Default;

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
        public RenderFragment Header { get; set; }

        [Parameter]
        public bool NoFlex { get; set; }

        [Parameter]
        public RenderFragment Footer { get; set; }

        [Parameter]
        public string EmptyText { get; set; }

        [Parameter]
        public IReadOnlyList<TItem> DataSource { get; set; }

        [Parameter]
        public RenderFragment<TItem> Item { get; set; }

        [Parameter]
        public Action<TItem> OnClick { get; set; }

        public ListView()
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
            NoFlexHandle();
            ItemLayoutHandler();
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
            _classHelper.AddOrRemove(_notEmptyAfterLastItemClassName, () => Footer != null);
        }

        private void NoFlexHandle()
        {
            if (NoFlex)
            {
                _listItemClassName += " " + _noFlexClassName;
            }
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

        private void ItemLayoutHandler()
        {
            _classHelper.AddOrRemove(_verticalClassName, () => ItemLayout == LNListItemLayout.Vertical);
        }

        private void OnClickHandler(TItem item)
        {
            OnClick?.Invoke(item);
        }
    }
}
