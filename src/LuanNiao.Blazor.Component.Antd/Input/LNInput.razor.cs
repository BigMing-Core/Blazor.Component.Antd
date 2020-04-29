using System;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class LNInput
    {
        private bool _hasAddOn;
        private bool _hasAffix;

        private readonly List<string> _addOnClassName = new List<string> { LNInputClassName.StaticAddOnClassName };
        private readonly List<string> _affixClassName = new List<string> { LNInputClassName.StaticAffixClassName };

        public string AddOnClassName => string.Join(" ", _addOnClassName);

        public string AffixClassName => string.Join(" ", _affixClassName);

        private string _type = "text";

        [Parameter]
        public string Placeholder { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public string DefaultValue { get; set; }

        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public int MaxLength { get; set; }

        [Parameter]
        public LNInputSize Size { get; set; }

        [Parameter] 
        public LNInputType Type { get; set; } = LNInputType.Text;

        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public bool AllowClear { get; set; }

        [Parameter]
        public RenderFragment AddOnAfter { get; set; }

        [Parameter]
        public RenderFragment AddOnBefore { get; set; }

        [Parameter]
        public RenderFragment Prefix { get; set; }

        [Parameter]
        public RenderFragment Suffix { get; set; }

        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        public LNInput()
        {
            _hasAffix = false;
            _classHelper.SetStaticClass(LNInputClassName.StaticClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleAddOnOrAffixDefined();
            HandleSize();
            HandleType();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleDisabled();
            HandleValue();
            Flush();  
        }

        private void HandleDisabled()
        {
            _classHelper.AddOrRemove(LNInputClassName.DisabledClassName, () => Disabled);

            if (_hasAddOn && Disabled)
            {
                _addOnClassName.Add(LNInputClassName.DisabledAddOnClassName);
            }

            if (_hasAffix && Disabled)
            {
                _affixClassName.Add(LNInputClassName.DisabledAffixClassName);
            }
        }

        private void HandleSize()
        {
            switch (Size)
            {
                case LNInputSize.Large:
                {
                    _classHelper.AddCustomClass(LNInputClassName.LargeClassName);
                    if (_hasAddOn)
                    {
                        _addOnClassName.Add(LNInputClassName.LargeAddOnName);
                    }

                    if (_hasAffix)
                    {
                        _affixClassName.Add(LNInputClassName.LargeAffixClassName);
                    }

                    break;
                }
                case LNInputSize.Small:
                {
                    _classHelper.AddCustomClass(LNInputClassName.SmallClassName);
                    if (_hasAddOn)
                    {
                        _addOnClassName.Add(LNInputClassName.SmallAddOnClassName);
                    }

                    if (_hasAffix)
                    {
                        _affixClassName.Add(LNInputClassName.SmallAffixClassName);
                    }

                    break;
                }
            }
        }

        private void HandleAddOnOrAffixDefined()
        {
            _hasAddOn = AddOnBefore != null || AddOnAfter != null;
            _hasAffix = Prefix != null || Suffix != null;
        }

        private void HandleValue()
        {
            if (Value != null) return;
            Value = DefaultValue ?? "";
        }

        public void SetDisabled()
        {
            Disabled = true;
        }

        public void HandleType()
        {
            _type = Type switch
            {
                LNInputType.Date => "date",
                LNInputType.DateTime => "datetime",
                LNInputType.Number => "number",
                _ => "text"
            };
        }

        private Task OnValueChangeHandler(ChangeEventArgs args)
        {
            return ValueChanged.InvokeAsync(args.Value.ToString());
        }
    }
}
