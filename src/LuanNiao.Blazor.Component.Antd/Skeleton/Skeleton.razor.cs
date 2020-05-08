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
        private readonly ClassNameHelper _elementClassNameHelper = new ClassNameHelper();


        private const string _defaultClass = "ant-skeleton";
        private const string _activeClass = "ant-skeleton-active";
        private const string _elementClass = "ant-skeleton-element";

        private string _elementDefaultClass = "ant-skeleton-{0}";
        private string _elementLgClass = "{0}-lg";
        private string _elementSmClass = "{0}-sm";
        private string _elementSquareClass = "{0}-square";
        private string _elementCircleClass = "{0}-circle";

        [Parameter]
        public bool Active { get; set; }
        [Parameter]
        public ESize Size { get; set; }
        [Parameter]
        public Eshape Shape { get; set; }
        [Parameter]
        public EElement Element { get; set; }
        public bool IsElement { get => TitleWidth == 0 && Paragraph == null; }
        private string ElementClassName { get => this._elementClassNameHelper.Build(); }
        [Parameter]
        public decimal TitleWidth { get; set; }
        [Parameter]
        public SkeletonParagraphProps Paragraph { get; set; }
        [Parameter]
        public bool Loading { get; set; }
        public Skeleton()
        {
            _classHelper.SetStaticClass(_defaultClass);
        }
        protected override void OnInitialized()
        {
            _classHelper.AddOrRemove(_elementClass, condition: () => IsElement)
            .AddOrRemove(_activeClass, condition: () => Active);
            HandleElement();
        }

        private void HandleElement()
        {
            if (Element != EElement.Default)
            {
                _elementDefaultClass = string.Format(_elementDefaultClass, Element.ToString().ToLower());
                _elementClassNameHelper.AddCustomClass(_elementDefaultClass);
                _elementLgClass = string.Format(_elementLgClass, _elementDefaultClass);
                _elementSmClass = string.Format(_elementSmClass, _elementDefaultClass);
                _elementSquareClass = string.Format(_elementSquareClass, _elementDefaultClass);
                _elementCircleClass = string.Format(_elementCircleClass, _elementDefaultClass);
            }

            switch (Size)
            {
                case ESize.Default:
                    break;
                case ESize.Large:
                    _elementClassNameHelper.AddCustomClass(_elementLgClass);
                    break;
                case ESize.Small:
                    _elementClassNameHelper.AddCustomClass(_elementSmClass);
                    break;
                default:
                    break;
            }
            switch (Shape)
            {
                case Eshape.Square:
                    _elementClassNameHelper.AddCustomClass(_elementSquareClass);
                    break;
                case Eshape.Circle:
                    _elementClassNameHelper.AddCustomClass(_elementCircleClass);
                    break;
                default:
                    break;
            }
        }

    }
  
}
