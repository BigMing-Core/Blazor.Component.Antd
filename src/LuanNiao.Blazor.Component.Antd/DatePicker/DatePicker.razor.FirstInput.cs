using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading.Tasks;
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

        private readonly Stack<DatePickerType> _firstInputPickerStack = new Stack<DatePickerType>();

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                ElementInfo.BindFocusEvent(FirstInputID, nameof(FirstPickerFocus), this, true, true);
            }
        }


        [JSInvokable]
        public async Task FirstPickerFocus()
        {
#if DEBUG
            Console.WriteLine(nameof(FirstPickerFocus));

#endif 
            var thisLoopType = _firstInputPickerStack.Pop();
            await Server.ShowPicker(thisLoopType, FirstInputOuterID);
            Server.Stub.OnBodyClickHide = () =>
            {
                ResetOperationStack();
            };
            switch (thisLoopType)
            {
                case DatePickerType.Decade:
                    Server.Stub._decadePicker.ItemSelected = FirstInputDecadePickerSelected;
                    break;
                case DatePickerType.Year:
                    Server.Stub._yearPicker.ItemSelected = FirstInputYearPickerSelected;
                    Server.Stub._yearPicker.TitleClicked = async () =>
                    {
                        _firstInputPickerStack.Push(DatePickerType.Year);
                        _firstInputPickerStack.Push(DatePickerType.Decade);
                        Type = DatePickerType.Decade;
                        await FirstPickerFocus();
                    };
                    break;
                case DatePickerType.Month:
                    Server.Stub._monthPicker.ItemSelected = FirstInputMonthPickerSelected;
                    break;
                case DatePickerType.Week:
                    Server.Stub._weekPicker.ItemSelected = FirstInputWeekPickerSelected;
                    break;
                case DatePickerType.Date:
                    Server.Stub._datePicker.ItemSelected = FirstInputDatePickerSelected;
                    break;
                default:
                    break;
            }
        }

        private async void FirstInputHandleNext()
        {
            if (_firstInputPickerStack.Count > 0)
            {
                await FirstPickerFocus();
            }
        }

        private void FirstInputDecadePickerSelected((int leftYear, int rightYear) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.leftYear}-{dateInfo.rightYear}");
            this.Flush();
            FirstInputHandleNext();
        }
        private void FirstInputYearPickerSelected(int year)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{year}");
            this.Flush();
        }

        private void FirstInputMonthPickerSelected((int year, int month) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.year}-{dateInfo.month}");
            this.Flush();
        }


        private void FirstInputWeekPickerSelected((int year, int month, int week) dateInfo)
        {
            ElementInfo.SetElementValue(FirstInputID, $"{dateInfo.year}-{dateInfo.month}:{dateInfo.week}");
            this.Flush();
        }



        private void FirstInputDatePickerSelected(DateTime date)
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
