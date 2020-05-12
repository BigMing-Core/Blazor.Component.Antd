using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.DatePicker.StubChild
{
    public partial class DecadePicker
    {
        private int _currentLeftBoundaryYear;

        private string _titleNextBtnID;
        public string TitleNextBtnID
        {
            get
            {
                if (string.IsNullOrEmpty(_titleNextBtnID))
                {
                    _titleNextBtnID = $"LNDecadePicker_NextBtn_{IdentityKey}";
                }
                return _titleNextBtnID;
            }
        }

        private string _titlePrevBtnID;
        public string TitlePrevBtnID
        {
            get
            {
                if (string.IsNullOrEmpty(_titlePrevBtnID))
                {
                    _titlePrevBtnID = $"LNDecadePicker_PrevBtn_{IdentityKey}";
                }
                return _titlePrevBtnID;
            }
        }

        public int CurrentYear { get; set; } = DateTime.Now.Year;

        public Action<(int leftYear, int rightYear)> ItemSelected;

        public Action TitleClicked;
        private void OnTitleClicked()
        {
            TitleClicked?.Invoke();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            CalcBoundary();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindClickEvent();
            }
        }


        private void BindClickEvent()
        {
            ElementInfo.BindClickEvent(TitlePrevBtnID, nameof(PrevBtnClick), this, true, true);
            ElementInfo.BindClickEvent(TitleNextBtnID, nameof(NextBtnClick), this, true, true);
        }

        private void CalcBoundary()
        {
            _currentLeftBoundaryYear = (CurrentYear / 100) * 100 - 10;
        }

        [JSInvokable]
        public void PrevBtnClick()
        {
            if (CurrentYear - 100 < 0)
            {
                return;
            }
            CurrentYear -= 100;
            CalcBoundary();
            this.Flush();
        }
        [JSInvokable]
        public void NextBtnClick()
        {
            if ((CurrentYear + 100) > 7000)
            {
                return;
            }
            CurrentYear += 100;
            CalcBoundary();
            this.Flush();
        }

        private void ItemClicked(int leftYear, int rightYear)
        {
            ItemSelected?.Invoke((leftYear, rightYear));
#if DEBUG
            Console.WriteLine($"{leftYear}:{rightYear}");
#endif
        }
    }
}
