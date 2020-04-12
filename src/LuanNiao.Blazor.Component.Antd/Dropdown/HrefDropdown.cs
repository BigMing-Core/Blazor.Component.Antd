using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Dropdown
{
    public partial class HrefDropdown : AbsDropdown
    {
        private const string _hideDivClassName = "ant-dropdown-hidden";

        private readonly ClassNameHelper _hideDivInfo = new ClassNameHelper().SetStaticClass("ant-dropdown ant-dropdown-placement-bottomLeft").AddCustomClass(_hideDivClassName);
        private bool _inElementScope = false;

        private readonly OriginalStyleHelper _hideSubMenuDivStyle = new OriginalStyleHelper();

        private string _hideDivClassNameStr;
        private string _hideSubMenuDivStyleStr;

        public HrefDropdown()
        {
            _classHelper.SetStaticClass("ant-dropdown-link ant-dropdown-trigger");
            _hideDivClassNameStr = _hideDivInfo.Build();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }


        [JSInvokable]
        public async void OnMouseOver()
        {
            _inElementScope = true;
            var windowSize = await _jSRuntime.InvokeAsync<WindowSize>("LuanNiaoBlazor.GetWindowSize");
            var elementInfo = await ElementHelper.GetElementRectsByID($"main_{IdentityKey}");

            _hideSubMenuDivStyleStr = _hideSubMenuDivStyle
                .AddCustomStyle("left", $"{elementInfo.Left}px")
                .AddCustomStyle("top", $"{ elementInfo.Bottom}px")
                .AddCustomStyle("min-width", "74px")
                .Build();
            _hideDivClassNameStr = _hideDivInfo.RemoveCustomClass(_hideDivClassName).Build();
            this.Flush();
        }

        [JSInvokable]
        public void OnMouseOut()
        {
            _inElementScope = false;
            Task.Run(() =>
            {
                Task.Delay(100).Wait();
                if (_inElementScope)
                {
                    return;
                }
                _hideDivClassNameStr = _hideDivInfo.AddCustomClass(_hideDivClassName).Build();
                this.Flush();
            });
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                BindMouseEvent();
            }
        }


        private void BindMouseEvent()
        {
            _jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOver", $"main_{IdentityKey}", "OnMouseOver", DotNetObjectReference.Create(this));
            _jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOut", $"main_{IdentityKey}", "OnMouseOut", DotNetObjectReference.Create(this));
        }
    }
}
