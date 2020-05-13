using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class MonthPicker
    {


        [Parameter]
        public int CurrentYear { get; set; } = DateTime.Now.Year; 
        public int CurrentMonth { get; set; } = 1;

        public Action<(int year, int month)> ItemSelected;

        protected override void OnInitialized()
        { 
            base.OnInitialized();
        }
        public Action TitleClicked;
        private void OnTitleClicked()
        {
            TitleClicked?.Invoke();
        }
        private void PrevBtnClick()
        {
            if (CurrentYear - 1 < 0)
            {
                return;
            }
            CurrentYear--;
            this.Flush();
        }
        private void NextBtnClick()
        {
            if (CurrentYear + 1 > 7000)
            {
                return;
            }
            CurrentYear++;
            this.Flush();
        }
        private void ItemClicked(int month)
        {
            ItemSelected?.Invoke((CurrentYear, month));
#if DEBUG
            Console.WriteLine($"{month} ");
#endif
        }
    }
}
