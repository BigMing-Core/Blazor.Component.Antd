using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Dropdown
{
    public partial class HrefDropdown
    {
        private const string _hideDivClassName = "ant-dropdown-hidden";

        private readonly ClassNameHelper _hideDivInfo = new ClassNameHelper().SetStaticClass("ant-dropdown ant-dropdown-placement-bottomLeft").AddCustomClass(_hideDivClassName);
        private bool _inElementScope = false;

        [Parameter]
        public string HideDivClassName { get; set; }

        [Parameter]
        public RenderFragment Overlay { get; set; }

        [Inject]
        private IJSRuntime _jSRuntime { get; set; }

        public HrefDropdown()
        {
            _classHelper.SetStaticClass("ant-dropdown-link ant-dropdown-trigger");
            HideDivClassName = _hideDivInfo.Build();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }


        [JSInvokable]
        public void OnMouseEnter()
        {
            _inElementScope = true;
            HideDivClassName = _hideDivInfo.RemoveCustomClass(_hideDivClassName).Build();
            this.Flush(); 
        }

        [JSInvokable]
        public void OnMouseOut()
        {
            _inElementScope = false;
            Task.Run(() => {
                Task.Delay(100).Wait();
                if (_inElementScope)
                {
                    return;
                }
                HideDivClassName = _hideDivInfo.AddCustomClass(_hideDivClassName).Build();
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
            _jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOver", $"main_{IdentityKey}", "OnMouseEnter", DotNetObjectReference.Create(this));
            //_jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOver", $"hideDiv_{IdentityKey}", "OnMouseEnter", DotNetObjectReference.Create(this));
            _jSRuntime.InvokeVoidAsync("LuanNiaoBlazor.BindElementOnMouseOut", $"main_{IdentityKey}", "OnMouseOut", DotNetObjectReference.Create(this));
        }
    }
}
