using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class HeaderItem
    {

        private const string _headerStaticClassName = "ant-table-cell";
        public HeaderItem()
        {
            _classHelper.SetStaticClass(_headerStaticClassName);
        }
    }
}
