using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.JSInterop;
using LuanNiao.Core;
using System.ComponentModel.DataAnnotations;
using LuanNiao.Blazor.Component.Antd.Button;

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
        /// <summary>
        /// Title
        /// </summary>
        [Parameter] [Required] public RenderFragment Title { get; set; }
        /// <summary>
        /// Text of the OK button
        /// </summary>
        [Parameter] public string OkText { get; set; }

        /// <summary>
        /// Width
        /// </summary>
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// Whether to apply loading visual effect for OK button or not
        /// </summary>
        [Parameter] public bool ConfirmLoading { get; set; }

        [Parameter] public Action<LNModal> OnCancel { get; set; }
        /// <summary>
        /// Specify a function that will be called when the user clicks the Cancel button. 
        /// The parameter of this function is a function whose execution 
        /// should include closing the dialog. You can also just 
        /// return a promise and when the promise is resolved, 
        /// the modal dialog will also be closed
        /// </summary>
        [Parameter] public Action<LNModal> OnOk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<挂起>")]
        private LNButton _okBtn = null;

        private bool _blockClose = false;


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

        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                BindMouseEvent();
            }
            return base.OnAfterRenderAsync(firstRender);
        }

        private void HandleVisiable()
        {
            _maskClass.AddOrRemove("ant-modal-mask-hidden", condition: () => !this.Visible);
            if (this.Visible)
            {
                _styleHelper.RemoveCustomStyle("display");
            }
            else
            {
                _styleHelper.AddOrUpdateCustomStyle(new StyleItem() { StyleName = "display", Value = "none" });
            }
        }

        private void BindMouseEvent()
        {

            if (MaskClosable)
            {
                ElementInfo.BindClickEvent($"wrap_{IdentityKey}", nameof(OnCancelCallback), this, true);
            }
            ElementInfo.BindClickEvent($"lnBtnClose_{IdentityKey}", nameof(OnCancelCallback), this, true);
        }

        public void Hide()
        {
            this.Visible = false;
            HandleVisiable();
        }

        public void Show()
        {
            _okBtn.RecoverFromLoading();
            this.Visible = true;
            HandleVisiable();
        }

        public void ShowLoading()
        {
            _blockClose = true;
            _okBtn.BeginLoading();
        }

        public void HideLoading()
        {
            _blockClose = false;
            _okBtn.RecoverFromLoading();
        }

        #region Event
        [JSInvokable]
        public void OnCancelCallback()
        {
            if (_blockClose)
            {
                return;
            }
            OnCancel?.Invoke(this);
            this.Flush();
        }
        [JSInvokable]
        public void OnOkCallback()
        {
            if (ConfirmLoading)
            {
                ShowLoading();
            }
            OnOk?.Invoke(this);
        }
        #endregion
    }
}
