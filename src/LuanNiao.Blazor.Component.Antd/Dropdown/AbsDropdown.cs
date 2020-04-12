using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Dropdown
{
    public abstract class AbsDropdown : Core.LNBCBase
    {
        [Parameter]
        public TriggerType Trigger { get; set; }

        [Inject]
        public ElementInfo ElementHelper { get; set; }
        [Inject]
        protected IJSRuntime _jSRuntime { get; set; }

        [Parameter]
        public RenderFragment Overlay { get; set; }
    }
}
