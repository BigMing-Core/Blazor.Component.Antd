using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using LuanNiao.Blazor.Component.Antd.DatePicker.StubChild;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public partial class DatePicker
    {
        private string _firstInputValueStr;


        private string _firstInputOuterID;
        private string FirstInputOuterID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_firstInputOuterID))
                {
                    _firstInputOuterID = $"FirstInputOuterID_{IdentityKey}"; ;
                }
                return _firstInputOuterID;
            }
        }

        private string _firstInputID;
        private string FirstInputID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_firstInputID))
                {
                    _firstInputID = $"FirstInputID_{IdentityKey}"; ;
                }
                return _firstInputID;
            }
        }


        [Parameter]
        public string FirstInputPlaceHolder { get; set; } = "click to select";

        private readonly Stack<DatePickerType> _pickerStack=new Stack<DatePickerType>();

        private async void FirstPickerFocus()
        {
            await Server.ShowPicker(Type, FirstInputOuterID);
            switch (Type)
            {
                case DatePickerType.Decade:
                    Server.Stub._decadePicker.ItemSelected = DecadePickerSelected;
                    Server.Stub.OnBodyClickHide = () =>
                    {
                        ResetOperationStack();
                    };
                    break;
                case DatePickerType.Year:
                    Server.Stub._yearPicker.ItemSelected = YearPickerSelected;
                    break;
                case DatePickerType.Month:
                    Server.Stub._monthPicker.ItemSelected = MonthPickerSelected;
                    break;
                case DatePickerType.Week:
                    Server.Stub._weekPicker.ItemSelected = WeekPickerSelected;
                    break;
                case DatePickerType.Date:
                    Server.Stub._datePicker.ItemSelected = DatePickerSelected;
                    break;
                default:
                    break;
            }
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
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.year}-{dateInfo.month}:{dateInfo.week}");
            this.Flush();
        }



        private void DatePickerSelected(DateTime date)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{date:yyyy-MM-dd}");
            this.Flush();
        }



        private async void FirstInputClearValue()
        {
            _firstInputValueStr = "";
            ElementInfo.SetElementValue(FirstInputID, _firstInputValueStr);
            await this.FlushAsync();
        }
    }
}
