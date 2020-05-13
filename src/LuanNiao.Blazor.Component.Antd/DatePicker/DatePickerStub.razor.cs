using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LuanNiao.Blazor.Component.Antd.DatePicker.StubChild;

namespace LuanNiao.Blazor.Component.Antd.DatePicker
{
    public partial class DatePickerStub
    {

        [Inject]
        public DatePickerServer Server { get; set; }

        public DecadePicker _decadePicker;
        public YearPicker _yearPicker;
        public MonthPicker _monthPicker;
        public WeekPicker _weekPicker;
        public DatePanelPicker _datePicker;
        public Action OnBodyClickHide;


        private ElementRects _elementRects;

        private bool _showDecade = false;
        private bool _showYear = false;
        private bool _showMonth = false;
        private bool _showWeek = false;
        private bool _showDate = false;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            BindBodyEvent();
        }

        private void BindBodyEvent()
        {
            BodyEventHub.Click += BodyEventHub_Click;
        }

        protected override void Dispose(bool flag)
        {
            base.Dispose(flag);
            BodyEventHub.Click -= BodyEventHub_Click;
        }

        private void BodyEventHub_Click(WindowEvent obj)
        {
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false; 
            this.Flush();
#if DEBUG
            Console.WriteLine(nameof(BodyEventHub_Click));
#endif
            OnBodyClickHide?.Invoke();
        }

        private async Task ShowPicker(string targetElementID)
        {

            if (string.IsNullOrWhiteSpace(targetElementID))
            {
                return;
            }
            _elementRects = await ElementInfo.GetElementRectsByID(targetElementID);
        }

        public async Task ShowDecadePicker(string targetElementID)
        {
           await ShowPicker(targetElementID);
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false;
            _showDecade = true;
            this.Flush();
        }
        public async Task ShowYearPicker(string targetElementID)
        {
            await ShowPicker(targetElementID);
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false;
            _showYear = true;
            this.Flush();
        }
        public async Task ShowMonthPicker(string targetElementID)
        {
            await ShowPicker(targetElementID);
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false;
            _showMonth = true;
            this.Flush();
        }
        public async Task ShowWeekPicker(string targetElementID)
        {
            await ShowPicker(targetElementID);
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false;
            _showWeek = true;
            this.Flush();
        }
        public async Task ShowDatePicker(string targetElementID)
        {
            await ShowPicker(targetElementID);
            _showDecade = _showYear = _showMonth = _showWeek = _showDate = false;
            _showDate = true;
            this.Flush();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                Server.Stub = this;
            }
        }
    }
}
