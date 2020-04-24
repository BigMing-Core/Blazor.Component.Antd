using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using LuanNiao.Core;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;

namespace LuanNiao.Blazor.Component.Antd.Avatar
{
    /// <summary>
    /// Avatars can be used to represent people or objects.
    /// It supports images, Icons, or letters.
    /// </summary>
    public partial class LNAvatar
    {
        public enum AShape
        {
            Circle,
            Square
        }

        public enum ASize
        {
            Default,
            Small,
            Large
        }

        private readonly OriginalStyleHelper _stringStyle = new OriginalStyleHelper();

        /// <summary>
        /// custom icon type for an icon avatar
        /// </summary>
        [Parameter]
        public RenderFragment Icon { get; set; }
        /// <summary>
        /// the shape of avatar
        /// </summary>
        [Parameter]
        public AShape Shape { get; set; }
        /// <summary>
        /// the size of the avatar
        /// </summary>
        [Parameter]
        public UnionType<ASize, int> Size { get; set; }
        /// <summary>
        /// the address of the image for an image avatar
        /// </summary>
        [Parameter]
        public string Src { get; set; }
        /// <summary>
        /// a list of sources to use for different screen resolutions
        /// </summary>
        [Parameter]
        public string SrcSet { get; set; }
        /// <summary>
        /// 	handler when img load error, return false to 
        /// 	prevent default fallback behavior
        /// </summary>
        [Parameter]
        public Action<LNAvatar> OnError { get; set; }
        /// <summary>
        /// This attribute defines the alternative text describing the image
        /// </summary>
        [Parameter]
        public string Alt { get; set; }


        /// <summary>
        /// className of wrapper when Spin has children
        /// </summary>
        public string StringStyleName { get { return _stringStyle.Build(); } set { _stringStyle.AddCustomStyleStr(value); } }
        public LNAvatar()
        {
            _classHelper.AddCustomClass("ant-avatar");
        }
        protected override void OnInitialized()
        {
            HandleShape();
            HandleSize();
            _classHelper.AddOrRemove("ant-avatar-icon", condition: () => Icon != null);
            _classHelper.AddOrRemove("ant-avatar-image", condition: () => Src != null);
        }
        private void HandleShape()
        {
            _classHelper.AddOrRemove("ant-avatar-circle", condition: () => Shape == AShape.Circle);
            _classHelper.AddOrRemove("ant-avatar-square", condition: () => Shape == AShape.Square);

        }
        private void HandleSize()
        {
            if (Size?.Value != null)
            {
                Size.Switch((size1) =>
                {
                    switch (size1)
                    {
                        case ASize.Small:
                            _classHelper.AddCustomClass("ant-avatar-sm");
                            break;
                        case ASize.Large:
                            _classHelper.AddCustomClass("ant-avatar-lg");
                            break;
                    }

                }, (size2) =>
                {
                    _styleHelper.AddCustomStyle("width", size2 + "px;");
                    _styleHelper.AddCustomStyle("height", size2 + "px;");
                    _styleHelper.AddCustomStyle("line-height", size2 + "px;");
                    _styleHelper.AddCustomStyle("font-size", size2 / 2 + "px;");
                });
            }


        }

        private async void HandleTextTransfer()
        {
            if (ChildContent != null)
            {
                var node = await ElementInfo.GetElementRectsByID($"avatar_node_{ IdentityKey}");
                var child = await ElementInfo.GetElementRectsByID($"avatar_string_{IdentityKey}");
                var nodeWidth = node.OffsetWidth;
                var childWidth = child.OffsetWidth;
                var scale = nodeWidth - 8 < childWidth ? (nodeWidth - 8) / childWidth : 1;
                _stringStyle.AddCustomStyleStr($"transform: scale({scale}) translateX(-50%);");
                this.Flush();
            }
        }
        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }
        protected override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                HandleTextTransfer();
            }
            return base.OnAfterRenderAsync(firstRender);
        }
    }
}
