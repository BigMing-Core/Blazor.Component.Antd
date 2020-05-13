using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

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
            ElementInfo.BindClickEvent($"YearBtn_{IdentityKey}", nameof(OnTitleClicked), this, true, true);
        }
        public Action TitleClicked;

        [JSInvokable]
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
