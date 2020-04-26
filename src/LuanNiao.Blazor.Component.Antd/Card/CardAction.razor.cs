using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Card
{
    public partial class CardAction
    {
        [CascadingParameter]
        public LNCard Parent { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            Parent.AddAction(this);
        }
    }
}
