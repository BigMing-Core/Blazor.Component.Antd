using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public partial class LNRadio
    {
        //private readonly StyleItem[] _verticaStyleItem ={
        //    new StyleItem() { StyleName = "display", Value = "block" },
        //    new StyleItem() { StyleName = "height", Value = "30px" },
        //    new StyleItem() { StyleName = " line-height", Value = "30px" },
        //};
        //private readonly StyleItem[] _defaultStyleItem = new StyleItem[0];
        //private string _verticalStyle = "";
        //private readonly OriginalStyleHelper _verticalStyleHelper = new OriginalStyleHelper();

        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Checked { get; set; }
        [Parameter]
        public string Value { get; set; }
        [CascadingParameter]
        public LNRadioGroup RootGourp { get; set; }

        private const string _checkClass = "ant-radio-checked";
        private const string _disabledClass = "ant-radio-disabled";

        public LNRadio()
        {
            _classHelper.SetStaticClass("ant-radio");
        }
        protected override void OnParametersSet()
        {
            _classHelper.AddCustomClass(_checkClass, () => Checked)
              .AddOrRemove(_disabledClass, condition: () => Disabled );
            this.Flush();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (RootGourp != null)
            {
                SetPropWhitParent();
                RootGourp.ItemSelected += GotOtherItemSelectedEvent;
            }
        }
        private void SetPropWhitParent()
        {
            this.Disabled = RootGourp.Disabled;
            //_verticalStyle = _verticalStyleHelper.AddDiffCustomStyle(_verticaStyleItem, _defaultStyleItem, () => RootGourp.IsVertical).Build();
        }
        private void HandleClickEvent()
        {
            if (this.Disabled)
            {
                return;
            }
            if (RootGourp != null)
            {
                RootGourp.Triggered(this);
            }
            else
            {
                Checked = !Checked;
                _classHelper.AddOrRemove(_checkClass, () => Checked);
            }
            this.Flush();
        }

        private void GotOtherItemSelectedEvent(LNRadio targetItem)
        {
            if (targetItem.Equals(this))
            {
                Checked = true;
                this._classHelper.AddCustomClass(_checkClass);
                return;
            }
            Checked = false;
            this._classHelper.RemoveCustomClass(_checkClass);
            this.Flush();
        }
    }
}
