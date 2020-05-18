using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Select
{
    public partial class Select
    {

        private bool _showHidenDiv = false;
        private int _inputWidth = 120;
        private string _currentSelectText = string.Empty;
        private int _hideDivLeft = 0;
        private int _hideDivTop = 0;

        [Parameter]
        public RenderFragment Options { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                ElementEventHub.GetElementInstance($"LnSelect_input_{IdentityKey}")
                    .Bind(this
                    , nameof(IconClicked));
                ElementEventHub.GetElementInstance($"LnSelect_icon_{IdentityKey}")
                    .Bind(this
                    , nameof(IconClicked));
            }
        }


        [OnClickEvent]
        public async void IconClicked()
        {
            var selectDivInfo = await ElementInfo.GetElementRectsByID($"LNSelectDIV_{IdentityKey}");            
            _inputWidth = (int)selectDivInfo.Width;
            _showHidenDiv = true;
            _hideDivLeft = (int)selectDivInfo.OffsetLeft;
            _hideDivTop = (int)selectDivInfo.OffsetTop+ (int)selectDivInfo.OffsetHeight;
            this.Flush();
            BodyEventHub.Click += HideDiv;
        }

        private void HideDiv(WindowEvent _)
        {
            _showHidenDiv = false;
            this.Flush();
        }

        internal void SetCurrentSelectString(string text)
        {
            _currentSelectText = text; 
            HideDiv(default(WindowEvent));
        }
    }
}
