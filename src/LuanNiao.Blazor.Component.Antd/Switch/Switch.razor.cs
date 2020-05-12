using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Switch
{
    public partial class Switch
    {
        private const string _defaultClass = "ant-switch";
        private const string _checkClass = "ant-switch-checked";
        private const string _disabledClass = "ant-switch-disabled";
        public Switch()
        {
            _classHelper.SetStaticClass(_defaultClass);
        }

    }
}
