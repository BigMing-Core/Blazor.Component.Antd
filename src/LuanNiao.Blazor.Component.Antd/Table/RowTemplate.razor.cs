using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class RowTemplate
    {
        private const string _rowStaticClassName = "ant-table-row";
        private const string _rowLevel0ClassName = "ant-table-row-level-0";

        public RowTemplate()
        {
            _classHelper.SetStaticClass(_rowStaticClassName).AddCustomClass(_rowLevel0ClassName);
        }

    }
}
