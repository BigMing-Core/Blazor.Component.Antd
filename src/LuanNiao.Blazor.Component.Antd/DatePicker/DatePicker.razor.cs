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

        private string _inputOuterID;
        private string InputOuterID
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_inputOuterID))
                {
                    _inputOuterID = $"FirstPicker_{IdentityKey}"; ;
                }
                return _inputOuterID;
            }
        }
    }
}
