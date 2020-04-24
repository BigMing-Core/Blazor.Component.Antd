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
        [Parameter]
        public int Count
        {
            get => _count; set { _count = value; }
        }






        public LNBadge()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleCount();
        }


        private void HandleCount()
        {
            _countStrList.Clear();
            _countStrList.AddRange(_count.ToString().ToCharArray().Select(item => item.ToString()));
        }


        public void AddNum(int data = 1)
        {
            _count += data;
            this.HandleCount();
        }
    }
}
