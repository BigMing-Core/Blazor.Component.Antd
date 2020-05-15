using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestPages.Pages
{
    public partial class EventHubTest
    {
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                ElementEventHub.RegistInstance(this);
            }
        }

        
        [OnClickEvent($"TestInfo{IdentityKey}")]
        public void OnClick()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnClick)}");
        }
    }
}
