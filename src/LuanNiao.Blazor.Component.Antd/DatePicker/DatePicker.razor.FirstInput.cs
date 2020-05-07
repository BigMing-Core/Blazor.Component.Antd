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

        private string _firstInputID;
        private string FirstInputID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_firstInputID))
                {
                    _firstInputID = $"FirstPicker_{IdentityKey}"; ;
                }
                return _firstInputID;
            }
        }


        [Parameter]
        public string PlaceHolder { get; set; } = "click to select";



        private void BindFirstPickerEvent()
        {
            ElementInfo.BindFocusEvent(FirstInputID, nameof(FirstPickerFocus), this, true);
        }

        [JSInvokable]
        public void FirstPickerFocus()
        {

        }

        private async void FirstInputClearValue()
        {
            _firstInputValueStr = "";
            ElementInfo.SetElementValue(FirstInputID, _firstInputValueStr);
            await this.FlushAsync();
        }
    }
}
