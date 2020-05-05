using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Table
{
    public partial class RowColumn
    {

        private const string _staticClassName = "ant-table-cell";

        public RowColumn()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

    }
}
