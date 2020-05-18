using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Select
{
    public partial class SelectOption
    {

        [CascadingParameter]
        public Select ParentSelect { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                ElementEventHub.GetElementInstance(IdentityKey)
                    .Bind(this
                    , nameof(OnClick));
            }
        }

        [OnClickEvent]
        public async void OnClick()
        {
            var text = await ElementInfo.GetElementInnerText($"MyInfoDiv_{IdentityKey}");
            ParentSelect.SetCurrentSelectString(text);
        }
    }
}
