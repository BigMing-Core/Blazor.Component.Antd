using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class DatePanelPicker
    {
        [Parameter]
        public int CurrentMonth { get; set; } = DateTime.Now.Month;

        [Parameter]
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        [Parameter]
        public int CurrentDay { get; set; } = DateTime.Now.Day;
         
        public DateTime CurrentSelectDate { get; set; } = DateTime.Now;

        public Action<DateTime> ItemSelected;

        public Action TitleYearClicked;
        private void OnTitleYearClicked()
        {
            TitleYearClicked?.Invoke();
        }

        public Action TitleWeekClicked;
        private void OnTitleWeekClicked()
        {
            TitleWeekClicked?.Invoke();
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            Core.Translater.CultureChanged += OnCultureChanged;
        }

        private void OnCultureChanged(string _)
        {
            this.Flush();
        }


        protected override void Dispose(bool flag)
        {
            base.Dispose(flag);
            Core.Translater.CultureChanged -= OnCultureChanged;
        }

        private void OnClickItem(DateTime date)
        {
            ItemSelected?.Invoke(date);
            this.Flush();
        }


        private void PrevMonth()
        {
            if (CurrentMonth - 1 <= 0)
            {
                return;
            }
            CurrentMonth -= 1;
            this.Flush();
        }
        private void NextMonth()
        {
            if (CurrentMonth + 1 >= 13)
            {
                return;
            }
            CurrentMonth += 1;
            this.Flush();
        }
        private void PrevYear()
        {
            if (CurrentYear - 1 <= 1)
            {
                return;
            }
            CurrentYear -= 1;
            this.Flush();
        }
        private void NextYear()
        {
            if (CurrentYear + 1 >= 7000)
            {
                return;
            }
            CurrentYear += 1;
            this.Flush();
        }
    }
}
