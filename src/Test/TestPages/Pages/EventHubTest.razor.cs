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
                ElementEventHub.GetElementItem("TestInfo").Bind(this);
            }
        }
    }
}
