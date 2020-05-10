using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public partial class DatePicker
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:添加只读修饰符", Justification = "<挂起>")]
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


        private async void FirstPickerFocus()
        {

            await Server.ShowMonthPicker(FirstInputOuterID);
            Server.Stub._monthPicker.ItemSelected = ((int year, int month) dataInfo) =>
            {
                ElementInfo.SetElementValue(FirstInputID, $"{dataInfo.year}-{dataInfo.month}");
                this.Flush();
            };
        }

        private async void FirstInputClearValue()
        {
            _firstInputValueStr = "";
            ElementInfo.SetElementValue(FirstInputID, _firstInputValueStr);
            await this.FlushAsync();
        }
    }
}
