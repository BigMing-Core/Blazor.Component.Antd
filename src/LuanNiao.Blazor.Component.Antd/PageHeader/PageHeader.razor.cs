using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Text;
using LuanNiao.Blazor.Component.Antd.Avatar;
using LuanNiao.Blazor.Component.Antd.Tag;
using LuanNiao.Blazor.Component.Antd.Breadcrumb;

namespace LuanNiao.Blazor.Component.Antd.PageHeader
{
    public partial class PageHeader
    {

        private const string _defaultStaticClassName = "ant-breadcrumb";


        /// <summary>
        /// 自定义标题文字
        /// </summary>
        [Parameter]
        public string Title { get; set; }

        /// <summary>
        /// 自定义的二级标题文字
        /// </summary>
        [Parameter]
        public string SubTitle { get; set; }

        /// <summary>
        /// 自定义 back icon 
        /// </summary>
        [Parameter]
        public RenderFragment BackIcon { get; set; }

        /// <summary>
        /// pageHeader 的类型，将会改变背景颜色
        /// </summary>
        [Parameter]
        public bool Ghost { get; set; } = true;

        /// <summary>
        /// 标题栏旁的头像
        /// </summary>
        [Parameter]
        public LNAvatar Avatar { get; set; }

        /// <summary>
        /// title 旁的 tag 列表
        /// </summary>
        [Parameter]
        public Tag.Tag[] Tags { get; set; }

        /// <summary>
        /// 操作区，位于 title 行的行尾
        /// </summary>
        [Parameter]
        public RenderFragment Extra { get; set; }

        /// <summary>
        /// 面包屑的配置
        /// </summary>
        [Parameter]
        public LNBreadcrumb Breadcrumb { get; set; }

        /// <summary>
        /// 内容区
        /// </summary>
       [Parameter]
        public RenderFragment Content { get; set; }

        /// <summary>
        /// PageHeader 的页脚，一般用于渲染 TabBar
        /// </summary>
        [Parameter]
        public RenderFragment Footer { get; set; }

        ///// <summary>
        ///// 返回按钮的点击事件
        ///// </summary>
        //[Parameter]
        //public EventCallback<MouseEventArgs> OnBack { get; set; }

    }
}
