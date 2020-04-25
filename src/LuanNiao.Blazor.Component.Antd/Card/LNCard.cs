using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Card
{

    public partial class LNCard
    {

        private const string _staticClassName = "ant-card";
        private const string _innerClassName = "ant-card-type-inner";
        private const string _borderedClassName = "ant-card-bordered";
        private const string _hoverableClassName = "ant-card-hoverable";
        /*did we need the interlocked ? Who cares~ (•́⌄•́๑)૭✧ we change this if we found the bug~ Yes!!!!!*/
        private int _currentActionCount = 0;

        public LNCard()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }

        internal double SingleActionWidth { get; private set; }

        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public bool Inner { get; set; }

        [Parameter]
        public bool Hoverable { get; set; } = false;

        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public RenderFragment Cover { get; set; }

        [Parameter]
        public RenderFragment Extra { get; set; }

        [Parameter]
        public RenderFragment Actions { get; set; }


        private readonly ClassNameHelper _metaClassNameHelper = new ClassNameHelper();
        private readonly OriginalStyleHelper _metaStyleHelper = new OriginalStyleHelper();
        [Parameter]
        public RenderFragment MetaAvatar { get; set; }
        [Parameter]
        public string MetaClassName { get => _metaClassNameHelper.Build(); set { _metaClassNameHelper.AddCustomClass(value); } }
        [Parameter]
        public string MetaStyle { get => _metaStyleHelper.Build(); set { _metaStyleHelper.AddCustomStyleStr(value); } }
        [Parameter]
        public RenderFragment MetaDescription { get; set; }
        [Parameter]
        public RenderFragment MetaTitle { get; set; }




        internal void AddAction(CardAction action)
        {
            action.Disposing += () =>
            {
                _currentActionCount--;
                SingleActionWidth = Math.Round((float)100 / (float)_currentActionCount, 2);
            };
            _currentActionCount++;
            SingleActionWidth = Math.Round((float)100 / (float)_currentActionCount, 2);

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleBordered();
            HandleHoverable();
            HandleInner();
        }


        private void HandleInner()
        {
            _classHelper.AddCustomClass(_innerClassName, () => Inner);
        }

        private void HandleHoverable()
        {
            _classHelper.AddCustomClass(_hoverableClassName, () => Hoverable);
        }

        private void HandleBordered()
        {
            _classHelper.AddCustomClass(_borderedClassName, () => Bordered);
        }
    }
}
