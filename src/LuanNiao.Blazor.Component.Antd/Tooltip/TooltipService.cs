using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Tooltip
{
    public class TooltipService
    {

        private readonly ObservableCollection<LNTooltip> _toolTips = new ObservableCollection<LNTooltip>();
        public ObservableCollection<LNTooltip> ToolTips { get => _toolTips; }

        public Action NeedFlush;

        private LNTooltipStub _currentStub = null;
        public LNTooltipStub CurrentStub
        {
            get => _currentStub;
            internal set
            {
                _currentStub = value;
                value.Disposing += (() =>
                {
                    if (_currentStub == value)
                    {
                        _currentStub = null;
                    }
                });
            }
        }

        public TooltipService Show(LNTooltip item)
        {
            lock (ToolTips)
            {
                ToolTips.Add(item);
            }
            item.Disposing += () =>
            {
                ToolTips.Remove(item);
            };

            return this;
        }
    }
}
