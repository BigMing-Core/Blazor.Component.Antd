using LuanNiao.Blazor.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public class RadioBase : LNBCBase
    {
        internal int _checkValue;
        internal void Triggered(Radio sourceItem)
        {
            this.ItemSelected?.Invoke(sourceItem);
        }
        /// <summary>
        /// there's some on selected
        /// </summary>
        internal event Action<Radio> ItemSelected;
    }
}
