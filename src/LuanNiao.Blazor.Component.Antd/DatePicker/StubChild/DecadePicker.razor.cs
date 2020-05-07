using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class DecadePicker
    {
        private int _currentLeftBoundaryYear;


        [Parameter]
        public int CurrentYear { get; set; } = DateTime.Now.Year;

        [Parameter]
        public Action<int, int> ItemSelected { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            CalcBoundary();
        }

        private void CalcBoundary()
        {
            _currentLeftBoundaryYear = (CurrentYear / 100) * 100-10;
        }
        private void PrevBtnClick()
        {
            if (CurrentYear-100<0)
            {
                return;
            }
            CurrentYear -= 100;
            CalcBoundary();
            this.Flush();
        } 
        private void NextBtnClick()
        {
            if (CurrentYear+100>7000)
            {
                return;
            }
            CurrentYear += 100;
            CalcBoundary();
            this.Flush();
        }
        private void ItemClicked(int leftYear,int rightYear)
        {
            ItemSelected?.Invoke(leftYear, rightYear);
#if DEBUG
            Console.WriteLine($"{leftYear}:{rightYear}");
#endif
        }
    }
}
