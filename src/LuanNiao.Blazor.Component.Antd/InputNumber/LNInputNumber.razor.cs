using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.InputNumber
{
    public partial class LNInputNumber
    {

        private const string _defaultStaticClassName = "ant-input-number";
        private const string _disabledClassName = "ant-input-number-disabled";
        private const string _inputStaticClassName = "ant-input-number-input";
        private const string _lgSizeClassName = "ant-input-number-lg";
        private const string _smallSizeClassName = "ant-input-number-sm";
        private double _value = 0;
        private string _displayValue = "";

        [Parameter]
        public ComponentSize Size { get; set; } = ComponentSize.Middle;

        [Parameter]
        public string Formatter { get; set; } = "{0}";

        [Parameter]
        public double Min { get; set; } = Double.MinValue;

        [Parameter]
        public double Step { get; set; } = 1;

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public double Max { get; set; } = Double.MaxValue;

        [Parameter]
        public double DefaultValue { get; set; } = 100;

        [Parameter]
        public Action<int> OnChange { get; set; }
        [Parameter]
        public double Value { get => _value; set { } }


        public LNInputNumber()
        {
            this._classHelper.SetStaticClass(_defaultStaticClassName);
        }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            this._classHelper
                .AddOrRemove(_disabledClassName, condition: () => Disabled);
        }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleDefaultValue();
            HandleSize();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);

            if (firstRender)
            {
                BindSpanClickEvent();
            }
        }



        [JSInvokable]
        public void OnUpClicked()
        {
#if DEBUG
            Console.WriteLine(nameof(OnUpClicked));
#endif
            if (_value == Max)
            {
                return;
            }
            _value += Step; 
            HandleDisplayValue();
        }




        [JSInvokable]
        public void OnDownClicked()
        {
#if DEBUG
            Console.WriteLine(nameof(OnDownClicked));
#endif
            if (_value == Min)
            {
                return;
            }
            _value -= Step;
            HandleDisplayValue();
        }


        private void HandleDisplayValue()
        {
            _displayValue = string.Format(this.Formatter, _value);
            this.Flush();
        }


        private void BindSpanClickEvent()
        {
            ElementInfo.BindClickEvent($"up_{this.IdentityKey}", nameof(OnUpClicked), this, true);
            ElementInfo.BindClickEvent($"down_{this.IdentityKey}", nameof(OnDownClicked), this, true);
        }

        private void HandleSize()
        {
            switch (Size)
            {
                case ComponentSize.Large:
                    _classHelper.AddCustomClass(_lgSizeClassName);
                    break;
                case ComponentSize.Small:
                    _classHelper.AddCustomClass(_smallSizeClassName);
                    break;
                case ComponentSize.Middle:
                default:
                    break;
            }
        }

        private void HandleDefaultValue()
        {
            this._value = DefaultValue;

            if (Max < Min)
            {
                throw new ArgumentException($"The max value {Max} lower than min value {Min};");
            }

            if (DefaultValue > Max)
            {
                this._value = Max;
            }
            if (DefaultValue < Min)
            {
                this._value = Min;
            }

            HandleDisplayValue();
        }



    }
}
