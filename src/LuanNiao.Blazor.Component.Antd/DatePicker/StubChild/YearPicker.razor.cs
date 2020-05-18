using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class YearPicker
    {
        private int _currentLeftBoundaryYear;
        [Parameter]
        public int CurrentYear { get; set; } = DateTime.Now.Year;


        public Action<int> ItemSelected { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CalcBoundary();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindTitleClickEvent();
            }
        }


        private void BindTitleClickEvent()
        {
            ElementEventHub.GetElementInstance($"YearBtn_{IdentityKey}")
                .Bind(this
                , nameof(OnTitleClicked)); 
        }
        public Action TitleClicked;

        [OnClickEvent]
        public void OnTitleClicked()
        {
            TitleClicked?.Invoke();
        }
        private void CalcBoundary()
        {
            _currentLeftBoundaryYear = (CurrentYear / 10) * 10 - 1;
        }
        private void PrevBtnClick()
        {
            if (CurrentYear - 10 < 0)
            {
                return;
            }
            CurrentYear -= 10;
            CalcBoundary();
            this.Flush();
        }
        private void NextBtnClick()
        {
            if (CurrentYear + 10 > 7000)
            {
                return;
            }
            CurrentYear += 10;
            CalcBoundary();
            this.Flush();
        }
        private void ItemClicked(int item)
        {
            ItemSelected?.Invoke(item);
        }
    }
}
