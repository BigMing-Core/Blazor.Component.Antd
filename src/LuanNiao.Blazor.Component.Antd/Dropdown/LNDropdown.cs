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


        [Parameter]
        public RenderFragment ContextFrame { get; set; }


        public LNDropdown()
        {
            _hideDivClassNameStr = _hideDivInfo.Build();
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (Trigger == TriggerType.ContextMenu)
            {
                HandleTriggerType();
            }
            else
            {
                HandleTheme();
            }
            _classHelper.AddCustomClass("ant-dropdown-trigger");
        }


        private void HandleTriggerType()
        {
            switch (Trigger)
            {
                case TriggerType.ContextMenu:
                    _classHelper.SetStaticClass("ln-site-dropdown-context-menu");
                    break;
                case TriggerType.Hover:
                case TriggerType.Click:
                default:
                    break;
            }
        }

        private void HandleTheme()
        {
            switch (Theme)
            {
                case DropdownTheme.HrefByA:
                    _classHelper.SetStaticClass("ant-dropdown-link");
                    break;
                case DropdownTheme.Button:
                    _classHelper.SetStaticClass("ant-btn");
                    break;
                default:
                    break;
            }
        }


        [JSInvokable]
        public async void WillShowSubInfo(WindowEvent data)
        {

            switch (this.Trigger)
            {
                case TriggerType.Hover:
                    this._inElementScope = true;
                    await ShowSubInfo();
                    break;
                case TriggerType.Click:
                    this._inElementScope = !this._inElementScope;
                    if (this._inElementScope)
                    {
                        await ShowSubInfo();
                    }
                    else
                    {
                        HideSubInfo();
                    }
                    break;
                case TriggerType.ContextMenu:
                    ShowSubInfo(data);
                    break;
                default:
                    break;
            }


        }

        private void ShowSubInfo(WindowEvent data)
        {
            _hideSubMenuDivStyleStr = _hideSubMenuDivStyle
                    .AddCustomStyle("left", $"{data.MouseEvent.ClientX}px")
                    .AddCustomStyle("top", $"{data.MouseEvent.ClientY}px")
                    .AddCustomStyle("min-width", "74px")
                    .Build();
            _hideDivClassNameStr = _hideDivInfo.RemoveCustomClass(_hideDivClassName).Build();
            this.Flush();
        }

        private async Task ShowSubInfo()
        {
            var elementRectInfo = await GetMainElementRects();
            /*Antd's style needs this 8px(•́⌄•́๑)૭✧ use to fix the div's location, if we haven't this 8px, the div will cover the button's bottom.*/
            var top = Theme == DropdownTheme.Button ? elementRectInfo.Bottom + 8 : elementRectInfo.Bottom;
            _hideSubMenuDivStyleStr = _hideSubMenuDivStyle
                    .AddCustomStyle("left", $"{elementRectInfo.Left}px")
                    .AddCustomStyle("top", $"{ top}px")
                    .AddCustomStyle("min-width", "74px")
                    .Build();
            _hideDivClassNameStr = _hideDivInfo.RemoveCustomClass(_hideDivClassName).Build();
            //}
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
            else if (this.Trigger == TriggerType.Hover)
            {
                ElementInfo.BindMouseOverEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this);
                ElementInfo.BindMouseOutEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            }
            else if (this.Trigger == TriggerType.ContextMenu)
            {
                ElementInfo.BindContextMenuEvent($"main_{IdentityKey}", nameof(WillShowSubInfo), this, true);
                ElementInfo.BindClickEvent($"main_{IdentityKey}", nameof(OnMouseOut), this);
            }
        }

        public async Task<ElementRects> GetMainElementRects()
        {
            return await ElementInfo.GetElementRectsByID($"main_{IdentityKey}");
        }
    }
}
