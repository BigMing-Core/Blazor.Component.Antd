using LuanNiao.Blazor.Core;
using LuanNiao.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Skeleton
{
    public partial class Skeleton
    {
        private readonly ClassNameHelper _avatarClassNameHelper = new ClassNameHelper().AddCustomClass(_avatartDefaultClass);


        private const string _defaultClass = "ant-skeleton";
        private const string _activeClass = "ant-skeleton-active";
        private const string _avatartDefaultClass = "ant-skeleton-avatar";
        private const string _avatarLgClass = "ant-skeleton-avatar-lg";
        private const string _avatarSmClass = "ant-skeleton-avatar-sm";
        private const string _avatarSquareClass = "ant-skeleton-avatar-square";
        private const string _avatarCircleClass = "ant-skeleton-avatar-circle";

        public enum ESize { 
            Default ,
            Large,
            Small
        }
        public enum Eshape {
            Square,
            Circle
        }
        public class SkeletonAvatarProps
        {
            public bool Active { get; set; }
            public ESize Size { get; set; }
            public Eshape Shape { get; set; }
        }

        [Parameter]
        public bool Active { get; set; }

        [Parameter]

        public SkeletonAvatarProps Avatar { get; set; }
        private string AvatarClassName { get => this._avatarClassNameHelper.Build(); }
        private bool _isAvatar = false;


        [Parameter]
        public bool Loading { get; set; }
        public Skeleton()
        {
            _classHelper.SetStaticClass(_defaultClass);
        }
        protected override void OnInitialized()
        {
            _classHelper.AddOrRemove(_activeClass, condition: () => Active);
            HandleAvatar();
        }

        private void HandleAvatar()
        {
            if (Avatar != null)
            {
                _isAvatar = true;
                switch (Avatar.Size)
                {
                    case ESize.Default:
                        break;
                    case ESize.Large:
                        _avatarClassNameHelper.AddCustomClass(_avatarLgClass);
                        break;
                    case ESize.Small:
                        _avatarClassNameHelper.AddCustomClass(_avatarSmClass);
                        break;
                    default:
                        break;
                }
                switch (Avatar.Shape)
                {
                    case Eshape.Square:
                        _avatarClassNameHelper.AddCustomClass(_avatarSquareClass);
                        break;
                    case Eshape.Circle:
                        _avatarClassNameHelper.AddCustomClass(_avatarCircleClass);
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
  
}
