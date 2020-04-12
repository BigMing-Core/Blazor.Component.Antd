using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class InlineMenu
    {
        public InlineMenu()
        {
            _classHelper
                .AddCustomClass($"ant-menu-inline", () => !Collapsed)
                .AddCustomClass($"ant-menu-inline-collapsed", () => Collapsed)
                .AddCustomClass($"ant-menu-vertical", () => Collapsed);
        }

        [Parameter]
        public bool Collapsed { get; set; }

        public event Action<bool> CollapsedStatusChanged;

        public  void InverseCollapseStatus()
        {
            Collapsed = !Collapsed;
            _classHelper                
                 .RemoveCustomClass($"ant-menu-inline", () => Collapsed)
                 .RemoveCustomClass($"ant-menu-inline-collapsed", () => !Collapsed)
                 .RemoveCustomClass($"ant-menu-vertical", () => !Collapsed)
                 .AddCustomClass($"ant-menu-inline", () => !Collapsed)
                 .AddCustomClass($"ant-menu-inline-collapsed", () => Collapsed)
                 .AddCustomClass($"ant-menu-vertical", () => Collapsed).Build();
            CollapsedStatusChanged?.Invoke(Collapsed);
            this.Flush();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleTheme();
        }

        private void HandleTheme()
        {
            switch (Theme)
            {
                case MenuTheme.Light:
                    _classHelper.AddCustomClass("ant-menu-light");
                    break;
                case MenuTheme.Dark:
                    _classHelper.AddCustomClass("ant-menu-dark");
                    break;
                default:
                    break;
            }
        } 
    }
}
