using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Skeleton
{
    public partial class Skeleton
    {
        private const string _defaultClass = "ant-skeleton";
        private const string _activeClass = "ant-skeleton-active";

        [Parameter]
        public bool Active { get; set; }
        public UnionType<bool,SkeletonAvatarProps> Avatar { get; set; }
        [Parameter]
        public bool Loading { get; set; }
        public Skeleton()
        {
            _classHelper.SetStaticClass(_defaultClass);
        }
        protected override void OnParametersSet()
        {
            _classHelper.AddOrRemove(_activeClass, condition: () => Active);
            this.Flush();
        }
    }
    public class SkeletonAvatarProps {
        public bool Active { get; set; }
        public int Size { get; set; }
        public int Shape { get; set; }
    }
}
