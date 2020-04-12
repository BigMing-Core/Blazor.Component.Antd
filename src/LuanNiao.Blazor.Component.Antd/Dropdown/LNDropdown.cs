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
    public partial class LNDropdown
    {
        private const string _hideDivClassName = "ant-dropdown-hidden";

        private readonly ClassNameHelper _hideDivInfo = new ClassNameHelper().SetStaticClass("ant-dropdown ant-dropdown-placement-bottomLeft").AddCustomClass(_hideDivClassName);
        private bool _inElementScope = false;

        private readonly OriginalStyleHelper _hideSubMenuDivStyle = new OriginalStyleHelper();

        private string _hideDivClassNameStr;
        private string _hideSubMenuDivStyleStr;


        [Parameter]
        public TriggerType Trigger { get; set; } = TriggerType.Hover;

        [Parameter]
        public RenderFragment Overlay { get; set; }

        [Parameter]
        public DropdownTheme Theme { get; set; } = DropdownTheme.HrefByA;

        public LNDropdown()
        {
            _hideDivClassNameStr = _hideDivInfo.Build();
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            switch (Theme)
            {
                case DropdownTheme.HrefByA:
                    _classHelper.SetStaticClass("ant-dropdown-link ant-dropdown-trigger");
                    break;
                case DropdownTheme.Button:
                    _classHelper.SetStaticClass("ant-btn ant-dropdown-trigger");
                    break;
                default:
                    break;
            }
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
            var elementRectInfo = await GetMainElementRects();
            var top = Theme == DropdownTheme.Button ? elementRectInfo.Bottom + 8/*Antd's style needs this 8px(•́⌄•́๑)૭✧*/ : elementRectInfo.Bottom;
            _hideSubMenuDivStyleStr = _hideSubMenuDivStyle
                    .AddCustomStyle("left", $"{elementRectInfo.Left}px")
                    .AddCustomStyle("top", $"{ top}px")
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
            }
            else
            {
                ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
                ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            }
        }

        public async Task<ElementRects> GetMainElementRects()
        {
            return await ElementInfo.GetElementRectsByID($"main_{IdentityKey}");
        }
    }
}
