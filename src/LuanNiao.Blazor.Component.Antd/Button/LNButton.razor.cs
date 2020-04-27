using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Button
{
    public partial class LNButton
    {
        public enum BType
        {
            Primary,
            Dashed,
            Link
        }



        public enum BShape
        {
            Circle,
            Round
        }

        public enum BHtmlType
        {
            Button,
            Submit,
            Reset
        }

        private string _htmlType;
        [Parameter]
        public ComponentSize? Size { get; set; }

        [Parameter]
        public BType? Type { get; set; }

        [Parameter]
        public BShape? Shape { get; set; }

        [Parameter]
        public BHtmlType? HtmlType { get; set; }

        [Parameter]
        public RenderFragment Icon { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public bool Ghost { get; set; }

        [Parameter]
        public bool Loading { get; set; }

        [Parameter]
        public bool Block { get; set; }

        [Parameter]
        public bool Danger { get; set; }

        [Parameter]
        public string Href { get; set; }

        [Parameter]
        public string Target { get; set; }

        [Parameter]
        public Action<LNButton> OnClickCallback { get; set; }

        public void BeginLoading(int delayMS = 0, int maxMS = 0)
        {
            if (delayMS > 0)
            {
                var delay = Task.Delay(delayMS).ContinueWith((_) =>
                {
                    this.IntoLoading();
                });
            }
            else
            {
                this.IntoLoading();
            }
            if (maxMS > 0)
            {
                var autoRelease = Task.Delay(maxMS).ContinueWith((_) =>
                {
                    this.RecoverFromLoading();
                });
            }
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                BindMouseEvent();
            }
        }

        public LNButton()
        {
            _classHelper.SetStaticClass("ant-btn");
        }

        protected override void OnInitialized()
        {
            HandleType();
            HandleShape();
            HandleSize();
            HandleDanger();
            HandleGhost();
            HandleBlock();
            HandleHtmlType();
            HandleIcon();
            HandleLoading();
        }

        private void BindMouseEvent()
        {
            ElementInfo.BindClickEvent($"lnButton_{IdentityKey}", nameof(OnElementClicked), this, true);
        }

        [JSInvokable]
        public async void OnElementClicked()
        {
            await Task.Run(() => { OnClickCallback?.Invoke(this); });
        }
        private void IntoLoading()
        {
            this.Disabled = true;
            this.Loading = true;
            this.HandleLoading();
            this.Flush();
        }

        public void RecoverFromLoading()
        {
            _classHelper.RemoveCustomClass("ant-btn-loading");
            this.Disabled = false;
            this.Loading = false;
            this.Flush();
        }

        private void HandleType()
        {
            if (Type != null)
            {
                switch (Type.Value)
                {
                    case BType.Primary:
                        _classHelper.AddCustomClass("ant-btn-primary");
                        break;
                    case BType.Dashed:
                        _classHelper.AddCustomClass("ant-btn-dashed");
                        break;
                    case BType.Link:
                        _classHelper.AddCustomClass("ant-btn-link");
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleSize()
        {
            if (Size != null)
            {
                switch (Size.Value)
                {
                    case ComponentSize.Large:
                        _classHelper.AddCustomClass("ant-btn-lg");
                        break;
                    case ComponentSize.Small:
                        _classHelper.AddCustomClass("ant-btn-sm");
                        break;
                    case ComponentSize.Middle:
                    default:
                        break;
                }
            }
        }

        private void HandleShape()
        {
            if (!Shape.HasValue) return;

            switch (Shape)
            {
                case BShape.Circle:
                    _classHelper.AddCustomClass("ant-btn-circle");
                    break;
                case BShape.Round:
                    _classHelper.AddCustomClass("ant-btn-round");
                    break;
            }
        }

        private void HandleHtmlType()
        {
            if (HtmlType.HasValue)
            {
                _htmlType = HtmlType.Value switch
                {
                    BHtmlType.Button => "button",
                    BHtmlType.Reset => "reset",
                    BHtmlType.Submit => "submit",
                    _ => null
                };
            }
            else
            {
                _htmlType = null;
            }
        }

        private void HandleDanger()
        {
            _classHelper.AddOrRemove("ant-btn-dangerous", () => Danger);
        }

        private void HandleGhost()
        {
            _classHelper.AddOrRemove("ant-btn-background-ghost", () => Ghost);
        }

        private void HandleBlock()
        {
            _classHelper.AddOrRemove("ant-btn-block", () => Block);
        }

        private void HandleLoading()
        {
            _classHelper.AddOrRemove("ant-btn-loading", () => Loading);
        }

        private void HandleIcon()
        {
            _classHelper.AddCustomClass("ant-btn-icon-only", when: () => ChildContent == null && Icon != null);
        }

    }
}
