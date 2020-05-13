using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public class DatePickerServer
    {
        public DatePickerStub Stub { get; internal set; }

  


        public async Task ShowPicker(DatePickerType type, string targetElementID)
        {
            if (Stub != null)
            {
                switch (type)
                {
                    case DatePickerType.Decade:
                        await Stub.ShowDecadePicker(targetElementID);
                        break;
                    case DatePickerType.Year:
                        await Stub.ShowYearPicker(targetElementID);
                        break;
                    case DatePickerType.Month:
                        await Stub.ShowMonthPicker(targetElementID);
                        break;
                    case DatePickerType.Week:
                        await Stub.ShowWeekPicker(targetElementID);
                        break;
                    case DatePickerType.Date:
                        await Stub.ShowDatePicker(targetElementID);
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
}
