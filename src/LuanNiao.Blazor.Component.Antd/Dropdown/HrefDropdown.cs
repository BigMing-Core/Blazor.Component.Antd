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
        public async void WillShowSubInfo()
        {
            if (this.Trigger == TriggerType.Hover)
            {
                this._inElementScope = true;
                await ShowSubInfo();
            }
            else
            {
                this._inElementScope = !this._inElementScope;
                if (this._inElementScope)
                {
                    await ShowSubInfo();
                }
                else
                {
                    HideSubInfo();
                }
            }

        }

        private async Task ShowSubInfo()
        {
            var windowSize = await WindowInfo.GetWindowSize();
            var elementRectInfo = await ElementInfo.GetElementRectsByID($"main_{IdentityKey}");

            _hideSubMenuDivStyleStr = _hideSubMenuDivStyle
                .AddCustomStyle("left", $"{elementRectInfo.Left}px")
                .AddCustomStyle("top", $"{ elementRectInfo.Bottom}px")
                .AddCustomStyle("min-width", "74px")
                .Build();
            _hideDivClassNameStr = _hideDivInfo.RemoveCustomClass(_hideDivClassName).Build();
            this.Flush();
        }

        public void HideSubInfo()
        {
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

        [JSInvokable]
        public void OnMouseOut()
        {
            _inElementScope = false;
            HideSubInfo();
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

            if (this.Trigger == TriggerType.Click)
            {
                ElementInfo.BindClickEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
                //_jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnClick", $"main_{IdentityKey}", "WillShowSubInfo", DotNetObjectReference.Create(this));
            }
            else
            {
                ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
                ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
                //_jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOver", $"main_{IdentityKey}", "WillShowSubInfo", DotNetObjectReference.Create(this));
                //_jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOut", $"main_{IdentityKey}", "OnMouseOut", DotNetObjectReference.Create(this));
            }

        }
    }
}
