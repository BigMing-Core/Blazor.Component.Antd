using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Button
{
    public partial class LNButton
    {
        public enum LBtnType
        {
            Primary,
            Dashed,
            Link
        }

        public enum LBtnSize
        {
            Large,
            Middle,
            Small
        }

        public enum LBtnShape
        {
            Circle,
            Round
        }

        public enum LBtnHtmlType
        {
            Button,
            Submit,
            Reset
        }

        [Parameter]
        public LBtnSize? BtnSize { get; set; }

        [Parameter]
        public LBtnType? BtnType { get; set; }

        [Parameter]
        public LBtnShape? BtnShape { get; set; }

        [Parameter]
        public LBtnHtmlType? BtnHtmlType { get; set; }

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


        private string _htmlType;


        public LNButton()
        {
            _classHelper.SetStaticClass("ant-btn");
        }


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

        private void IntoLoading()
        {
            _classHelper.AddCustomClass("ant-btn-loading");
            this.Disabled = true;
            this.Loading = true;
            this.Flush();
        }

        public void RecoverFromLoading()
        {
            _classHelper.RemoveCustomClass("ant-btn-loading");
            this.Disabled = false;
            this.Loading = false;
            this.Flush();
        }


        protected override void OnInitialized()
        {
            HandleType();
            HandleShape();
            HandleSize();
            HandleBooleanProperties();
            HandleHref();
            HandleHtmlType();
            HandleIcon();
        }

        private void HandleType()
        {
            if (BtnType != null)
            {
                switch (BtnType.Value)
                {
                    case LBtnType.Primary:
                        _classHelper.AddCustomClass("ant-btn-primary");
                        break;
                    case LBtnType.Dashed:
                        _classHelper.AddCustomClass("ant-btn-dashed");
                        break;
                    case LBtnType.Link:
                        _classHelper.AddCustomClass("ant-btn-link");
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleSize()
        {
            if (BtnSize != null)
            {
                switch (BtnSize.Value)
                {
                    case LBtnSize.Large:
                        _classHelper.AddCustomClass("ant-btn-lg");
                        break;
                    case LBtnSize.Small:
                        _classHelper.AddCustomClass("ant-btn-sm");
                        break;
                    case LBtnSize.Middle:
                    default:
                        break;
                }
            }
        }



        private void HandleHref()
        {
            //if (!string.IsNullOrWhiteSpace(Href))
            //{
            //    _href = Href;
            //    _target = !string.IsNullOrWhiteSpace(Target) ? Target : null;
            //}
            //else
            //{
            //    _href = null;
            //    _target = null;
            //}
        }

        private void HandleShape()
        {
            if (!BtnShape.HasValue) return;

            switch (BtnShape)
            {
                case LBtnShape.Circle:
                    _classHelper.AddCustomClass("ant-btn-circle");
                    break;
                case LBtnShape.Round:
                    _classHelper.AddCustomClass("ant-btn-round");
                    break;
            }
        }

        private void HandleHtmlType()
        {
            if (BtnHtmlType.HasValue)
            {
                _htmlType = BtnHtmlType.Value switch
                {
                    LBtnHtmlType.Button => "button",
                    LBtnHtmlType.Reset => "reset",
                    LBtnHtmlType.Submit => "submit",
                    _ => null
                };
            }
            else
            {
                _htmlType = null;
            }
        }

        private void HandleBooleanProperties()
        {
            if (Danger)
            {
                _classHelper.AddCustomClass("ant-btn-dangerous");
            }

            if (Ghost)
            {
                _classHelper.AddCustomClass("ant-btn-background-ghost");
            }

            if (Block)
            {
                _classHelper.AddCustomClass("ant-btn-block");
            }

            if (Loading)
            {
                Disabled = true;
                _classHelper.AddCustomClass("ant-btn-loading");
            }
        }

        private void HandleIcon()
        {
            _classHelper.AddCustomClass("ant-btn-icon-only", when: () => ChildContent == null && Icon != null);
        }

    }
}
