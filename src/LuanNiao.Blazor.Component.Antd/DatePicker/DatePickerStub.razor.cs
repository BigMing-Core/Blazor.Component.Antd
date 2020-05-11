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


        private ElementRects _elementRects;

        private bool _showDecade = false;
        private bool _showYear = false;
        private bool _showMonth = false;
        private bool _showWeek = false;
        private bool _showDate = false;



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
