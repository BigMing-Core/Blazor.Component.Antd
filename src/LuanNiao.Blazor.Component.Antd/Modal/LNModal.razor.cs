using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;

namespace LuanNiao.Blazor.Component.Antd.Modal
{
    public partial class LNModal
    {
        #region Public Parameters

        /// <summary>
        /// 	Whether a close (x) button is visible on top right of the modal dialog or not
        /// </summary>
        [Parameter] public bool Closable { get; set; } = true;
        /// <summary>
        /// custom close icon
        /// </summary>
        [Parameter] public RenderFragment CloseIcon { get; set; }
        /// <summary>
        /// Whether show mask or not.
        /// </summary>
        [Parameter] public bool Mask { get; set; } = true;
        /// <summary>
        /// 	Whether to close the modal dialog when the mask (area outside the modal) is clicked
        /// </summary>
        [Parameter] public bool MaskClosable { get; set; } = true;
        /// <summary>
        /// 	Whether the modal dialog is visible or not
        /// </summary>
        [Parameter] public bool Visible { get; set; }
        #endregion


        private readonly ClassNameHelper _maskClass = new ClassNameHelper()
            .SetStaticClass("ant-modal-mask");
        /// <summary>
        /// MaskClass
        /// </summary>
        private string MaskClass
        {
            get { return _maskClass.Build(); }
            set { _maskClass.AddCustomClass(value); }
        }

        public LNModal()
        {

        }
        protected override void OnInitialized()
        {
            HandleVisiable();
            ClassHelper.SetStaticClass("ant-modal-wrap");
            base.OnInitialized();
        }

        protected override Task OnParametersSetAsync()
        {
            HandleVisiable();
            return base.OnParametersSetAsync();
        }

        private void HandleVisiable()
        {
            _maskClass.AddOrRemove("ant-modal-mask-hidden", condition: () => this.Visible);
            if (this.Visible)
            {
                _styleHelper.RemoveCustomStyle("display");
            }
            else
            {
                _styleHelper.AddOrUpdateCustomStyle(new StyleItem() { StyleName = "display", Value = "none" });
            }
        }
    }
}
