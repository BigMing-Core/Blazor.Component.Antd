using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LuanNiao.Blazor.Component.Antd.Badge
{
    public partial class LNBadge
    {
        private const string _staticClassName = "ant-badge";

        private readonly List<string> _countStrList = new List<string>();
        private int _count = 0;
        private bool _overflowed = false;
        [Parameter]
        public int Count
        {
            get;set;
        }

        [Parameter]
        public bool ShowZero { get; set; } = false;
        [Parameter]
        public int OverflowCount { get; set; } = 99;
        [Parameter]
        public bool Dot { get; set; }




        public LNBadge()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _count = Count;
            HandleCount();
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
