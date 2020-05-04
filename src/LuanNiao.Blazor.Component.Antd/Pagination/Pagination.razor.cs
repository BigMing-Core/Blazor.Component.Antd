using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Pagination
{
    public partial class Pagination
    {

        private const string _paginationItemClassNameTemplate = "ant-pagination-item ant-pagination-item-{0}";
        private const string _currentPaginationItemClassNameTemplate = "ant-pagination-item ant-pagination-item-{0} ant-pagination-item-active";
        private const string _paginationPrevDisabledClassName = "ant-pagination-prev ant-pagination-disabled";
        private const string _paginationPrevClassName = "ant-pagination-prev";

        private const string _paginationNextDisabledClassName = "ant-pagination-next ant-pagination-disabled";
        private const string _paginationNextClassName = "ant-pagination-next";

        private int _pageCount = 0;
        

        public int CurrentPage { get; set; }

        private int _defaultCurrent = 0;
        [Parameter]
        public int DefaultCurrent
        {
            get => _defaultCurrent;
            set
            {
                if (this._hasFirstRender)
                {
                    return;
                }
                _defaultCurrent = CurrentPage = value;
            }
        }
        private int CurrentPageSize { get; set; } = 10;
        private int _defaultPageSize = 10;

        [Parameter]
        public int DefaultPageSize
        {
            get => _defaultPageSize;
            set
            {
                if (this._hasFirstRender)
                {
                    return;
                }
                _defaultPageSize = CurrentPageSize = value;
            }
        } 

        [Parameter]
        public bool SynchronizationIndex { get; set; }

        [Parameter]
        public int Total { get; set; }

        [Parameter]
        public Action<int> OnChange { get; set; }


        private void ItemClicked(int index)
        {
            CurrentPage = index;
            OnChange?.Invoke(index);
        }

        private void PrevClicked()
        {
            if ((CurrentPage - (SynchronizationIndex ? 1 : 0)) < 1)
            {
                return;
            }
            ItemClicked(--CurrentPage);
        }
        private void NextClicked()
        {
            if ((_pageCount - CurrentPage - (SynchronizationIndex ? 0 : 1)) < 1)
            {
                return;
            }
            ItemClicked(++CurrentPage);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CalcPageCount();
        }


        private void CalcPageCount()
        {
            _pageCount = Total / CurrentPageSize + (Total % CurrentPageSize == 0 ? 0 : 1);
        }
    }
}
