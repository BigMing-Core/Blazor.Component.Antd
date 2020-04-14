using LuanNiao.Blazor.Component.Antd.Icons;
using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Radio
{
    public partial class LNRadioItem
    {
        [Parameter]
        public bool Disabled { get; set; }
        [Parameter]
        public bool Checked { get; set; }
        //[CascadingParameter]
        //public int Value { get; set; }
        private const string _checkClass = "ant-radio-checked";
        private const string _disabledClass = "ant-radio-disabled";

        public LNRadioItem()
        {
            _classHelper.SetStaticClass("ant-radio");
        }
        protected override void OnParametersSet()
        {
            _classHelper.AddCustomClass(_checkClass, () => Checked)
              .AddOrRemove(_disabledClass, condition: () => Disabled);
            this.Flush();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.ItemSelected += GotOtherItemSelectedEvent;
        }

        private void HandleClickEvent()
        {
            if (this.Disabled)
            {
                return;
            }
            Checked = !Checked;
            this._classHelper.AddCustomClass(_checkClass);
            this.Triggered(this);
            this.Flush();
        }
 
        private void GotOtherItemSelectedEvent(LNRadioItem targetItem)
        {
            if (targetItem.Equals(this))
            {
                return;
            }
            this._classHelper.RemoveCustomClass(_checkClass);
            this.Flush();
        }
        [Parameter]
        public List<string> SelectItems { get; set; } = new List<string>();
        [Parameter]
        public string Key
        {
            get; set;
        }
        internal void Triggered(LNRadioItem sourceItem)
        {
            this.ItemSelected?.Invoke(sourceItem);
            if ( !this.SelectItems.Contains(sourceItem.IdentityKey))
            {
                this.SelectItems.Add(sourceItem.IdentityKey);
            }
            else
            {
                this.SelectItems.Clear();
                this.SelectItems.Add(sourceItem.IdentityKey);
            }
        }
        /// <summary>
        /// there's some on selected
        /// </summary>
        internal event Action<LNRadioItem> ItemSelected;
    }
}
