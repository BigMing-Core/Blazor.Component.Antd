using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class WeekPicker
    {
        private readonly GregorianCalendar _gc = new GregorianCalendar(GregorianCalendarTypes.USEnglish);
        [Parameter]
        public int CurrentMonth { get; set; } = DateTime.Now.Month;

        [Parameter]
        public int CurrentYear { get; set; } = DateTime.Now.Year;
        [Parameter]
        public int CurrentDay { get; set; } = DateTime.Now.Day;
         
        public int CurrentWeek { get; set; } = new GregorianCalendar(GregorianCalendarTypes.USEnglish).GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
         
        public Action<(int year, int month, int week)> ItemSelected { get; set; }


        public void SetWeek(DateTime dt)
        {
            CurrentWeek = _gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
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

        protected override void Dispose(bool flag)
        {
            Core.Translater.CultureChanged -= OnCultureChanged;
            base.Dispose(flag);
        }

        private void WeekClicked(int week)
        {
            CurrentWeek = week;
            this.Flush();
            ItemSelected?.Invoke((CurrentYear, CurrentMonth, CurrentWeek));
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
