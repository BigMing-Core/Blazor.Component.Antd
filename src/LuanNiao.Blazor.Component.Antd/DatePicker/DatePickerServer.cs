using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public class DatePickerServer
    {
        public DatePickerStub Stub { get; internal set; }

        public async Task ShowMonthPicker(string targetElementID)
        {
            if (Stub!=null)
            {
               await Stub.ShowMonthPicker(targetElementID);
            }
        }
        
    }
}
