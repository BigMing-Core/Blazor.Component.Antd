using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LuanNiao.Blazor.Component.Antd.Badge
{
    public partial class LNBadge
    {

        public enum BadgeStatus
        {
            Success,
            Error,
            Default,
            Processing,
            Warning
        }

        private const string _staticClassName = "ant-badge";
        private const string _noChildContentStaticClassName = "ant-badge ant-badge-not-a-wrapper";
        private string _onlyDotClassName = "ant-badge-status-dot";

        private readonly List<string> _countStrList = new List<string>();
        private int _count = 0;
        private bool _overflowed = false;
        [Parameter]
        public int Count
        {
            get; set;
        }
        [Parameter]
        public BadgeStatus? Status { get; set; } = null;
        [Parameter]
        public string Title { get; set; }
        [Parameter]
        public string Text { get; set; }
        [Parameter]
        public bool ShowZero { get; set; } = false;
        [Parameter]
        public int OverflowCount { get; set; } = 99;
        [Parameter]
        public bool Dot { get; set; }





        protected override void OnInitialized()
        {
            base.OnInitialized();
            _count = Count;
            HandleCount();
            HandleStaticClassName();
            HandleDotClassName();
        }

        private void HandleDotClassName()
        {
            if (Status == null)
            {
                return;
            }
            switch (Status.Value)
            {
                case BadgeStatus.Success:
                    _onlyDotClassName += " ant-badge-status-success";
                    break;
                case BadgeStatus.Error:
                    _onlyDotClassName += " ant-badge-status-error";
                    break;
                case BadgeStatus.Default:
                    _onlyDotClassName += " ant-badge-status-default";
                    break;
                case BadgeStatus.Processing:
                    _onlyDotClassName += " ant-badge-status-processing";
                    break;
                case BadgeStatus.Warning:
                    _onlyDotClassName += " ant-badge-status-warning";
                    break;
                default:
                    break;
            }
        }

        private void HandleStaticClassName()
        {

            _classHelper
                .SetStaticClass(_staticClassName, () => ChildContent != null)
                .SetStaticClass(_noChildContentStaticClassName, () => ChildContent == null);
        }


        private void HandleCount()
        {

            _countStrList.Clear();
            if (_count > OverflowCount)
            {
                _overflowed = true;
                _countStrList.AddRange(OverflowCount.ToString().ToCharArray().Select(item => item.ToString()));
                _countStrList.Add("+");
            }
            else
            {
                _overflowed = false;
                _countStrList.AddRange(_count.ToString().ToCharArray().Select(item => item.ToString()));
            }
        }


        public void AddNum(int data = 1)
        {
            _count += data;
            this.HandleCount();
            this.Flush();
        }
    }
}
