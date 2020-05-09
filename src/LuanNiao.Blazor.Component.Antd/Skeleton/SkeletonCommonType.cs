using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Skeleton
{
    public enum EElement { 
        Default,
        Button,
        Avatar,
        Input
    }
    public enum ESize
    {
        Default,
        Large,
        Small
    }
    public enum Eshape
    {
        Square,
        Circle
    }
    public class SkeletonAvatarProps
    {
        public bool Active { get; set; }
        public ESize Size { get; set; }
        public Eshape Shape { get; set; }
    }
    public class SkeletonParagraphProps {
        public int Rows { get; set; }
        public decimal Width { get; set; }
    }
}
