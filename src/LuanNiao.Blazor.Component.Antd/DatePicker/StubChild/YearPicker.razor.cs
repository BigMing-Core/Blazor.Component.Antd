using Microsoft.AspNetCore.Components;
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
        public Action TitleClicked;
        private void OnTitleClicked()
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
