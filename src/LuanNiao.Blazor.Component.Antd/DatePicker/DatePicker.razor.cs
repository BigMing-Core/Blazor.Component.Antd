using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public partial class DatePicker
    {
        [Inject]
        public DatePickerServer Server { get; set; }

        [Parameter]
        public DatePickerType Type { get; set; } = DatePickerType.Decade;



        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        private void DecadePickerSelected((int leftYear, int rightYear) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.leftYear}-{dateInfo.rightYear}");
            this.Flush();
        }
        private void YearPickerSelected(int year)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{year}");
            this.Flush();
        } 

        private void MonthPickerSelected((int year, int month) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.year}-{dateInfo.month}");
            this.Flush();
        }


        private void WeekPickerSelected((int year, int month, int week) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.year}-{dateInfo.month}-{dateInfo.week}");
            this.Flush();
        }



        private void DatePickerSelected(DateTime date)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{date:yyyy-MM-dd}");
            this.Flush();
        }
    }


}
