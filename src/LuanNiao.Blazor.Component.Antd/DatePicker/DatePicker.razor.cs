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
            ResetOperationStack();            
        }

        private void ResetOperationStack()
        {
#if DEBUG
            Console.WriteLine(nameof(ResetOperationStack));

#endif
            _firstInputPickerStack.Clear();
            _firstInputPickerStack.Push(Type);
        }


    }


}
