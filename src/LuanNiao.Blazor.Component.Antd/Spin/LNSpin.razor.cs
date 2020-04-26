using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Spin
{
    public partial class LNSpin
    {
        public enum SpinSize
        {
            Default,
            Small,
            Large
        }

        private readonly ClassNameHelper _blurClass = new ClassNameHelper().SetStaticClass("ant-spin-container");


        private const string _spinningClassName = "ant-spin-spinning";

        /// <summary>
        /// whether Spin is spinning
        /// </summary>
        [Parameter]
        public bool Spining { get; set; } = true;
        /// <summary>
        /// size of Spin, options: Small, Default and Large
        /// </summary>
        [Parameter]
        public SpinSize Size { get; set; }

        /// <summary>
        /// customize description content when Spin has children
        /// </summary>
        [Parameter]
        public string Tip { get; set; }
        /// <summary>
        /// specifies a delay in milliseconds for loading state (prevent flush)
        /// </summary>
        [Parameter]
        public int Delay{ get; set; }
        /// <summary>
        /// className of wrapper when Spin has children
        /// </summary>
        [Parameter]
        public string WrapperClassName { get; set; }
        /// <summary>
        /// Custom(document) node of the spinning indicator
        /// </summary>
        [Parameter]
        public RenderFragment Indicator { get; set; }


        public string BlurClass { get { return _blurClass.Build(); } set { _blurClass.AddCustomClass(value); } }

        public LNSpin()
        {
            _classHelper.SetStaticClass("ant-spin");
        }
        protected override void OnInitialized()
        {
            HandleSpining();
            HandleSize();

        }
        protected override void OnParametersSet()
        {
            if (this.Delay > 0)
            {
                Task.Delay(this.Delay).ContinueWith((_) => {
                    _classHelper.AddOrRemove(_spinningClassName, condition: () => Spining);
                    _blurClass.AddOrRemove("ant-spin-blur", condition: () => Spining);
                    this.Flush();
                });
            }
            else
            {
                _classHelper.AddOrRemove(_spinningClassName, condition: () => Spining);
                _blurClass.AddOrRemove("ant-spin-blur", condition: () => Spining);
                this.Flush();
            }
        }
        private void HandleSpining()
        {
            if (this.Spining)
            {
                if (this.Delay>0)
                {
                    Task.Delay(this.Delay).ContinueWith((_)=> {
                        _classHelper.AddCustomClass(_spinningClassName);
                        this.Flush();
                    });
                }
                else
                {
                    _classHelper.AddCustomClass(_spinningClassName);
                }
            }
        }
        private void HandleSize()
        {
            switch (Size)
            {
                case SpinSize.Small:
                    _classHelper.AddCustomClass("ant-spin-sm");
                    break;
                case SpinSize.Large:
                    _classHelper.AddCustomClass("ant-spin-lg");
                    break;
                case SpinSize.Default:
                default:
                    break;
            }
        }

        /// <summary>
        /// You can define default spin element globally.
        /// </summary>
        /// <param name="indicator"></param>
        [JSInvokable]
        public void SetDefaultIndicator(RenderFragment indicator)
        {
            this.Indicator = indicator;
        }
    }
}
