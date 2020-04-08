using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace LuanNiao.Blazor.Component.Antd.Menu
{
    public partial class SubMenu : LNBCBase
    {
        private const string _disableClassName = "ant-menu-item-disabled";
        private const string _openClassName = "ant-menu-submenu-open";
        private const string _activeClassName = "ant-menu-submenu-active";
        private const string _hideDivClassName = "ant-menu-submenu-hidden";
        private const string _inlineClassName = "ant-menu-inline";
        private const string _inlineSubClassName = "ant-menu-submenu-inline";
        private const string _verticalSubClassName = "ant-menu-submenu-vertical";
        private const string _inlineHorClassName = "ant-menu-submenu-horizontal";
        private const string _hidULClassName = "ant-menu-hidden";
        private const string _submenuUIVerticalStaticClassName = "ant-menu ant-menu-sub  ant-menu-vertical";
        private const string _submenuDivStaticClassName = "ant-menu-submenu ant-menu-submenu-popup ant-menu-light ant-menu-submenu-placement-bottomLeft";


        public SubMenu()
        {
            _classHelper.SetStaticClass("ant-menu-submenu");
            HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper.AddCustomClass(_hideDivClassName).Build();
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper.AddCustomClass(_hidULClassName).Build();
        }


        [Inject]
        public ElementInfo ElementHelper { get; set; }

        [Parameter]
        public string PopupClassName { get; set; }

        [Parameter]
        public string Key { get; set; }

        [Parameter]
        public List<MenuBase> Children { get; set; }

        [Parameter]
        public bool Disabled { get; set; }

        [Parameter]
        public RenderFragment Title { get; set; }
        [Parameter]
        public Action<SubMenu> OnTitleClick { get; set; }

        [CascadingParameter]
        public MenuBase RootMenuInstance { get; set; }

        [CascadingParameter]
        public SubMenu ParentSubmenu { get; set; }


        [Inject]
        public IJSRuntime JSRT { get; set; }


        private readonly ClassNameHelper _hideSubMenuDivClassNameHelper = new ClassNameHelper()
            .SetStaticClass(_submenuDivStaticClassName)
            .AddCustomClass(_hideDivClassName);
        private readonly ClassNameHelper _hideSubMenuULClassNameHelper = new ClassNameHelper()
            .SetStaticClass(_submenuUIVerticalStaticClassName)
            .AddCustomClass(_hidULClassName);
        private string HideSubMenuDivClassName { get; set; }
        private string HideSubMenuULClassName { get; set; }

        private readonly OriginalStyleHelper _hideSubMenuDivStyle = new OriginalStyleHelper();
        private string HideSubMenuDivStyle { get; set; }


        private readonly OriginalStyleHelper _hideSubMenuULStyle = new OriginalStyleHelper();
        private string HideSubMenuULStyle { get; set; }
        private bool _inThisElementScope = false;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleRootMenuType();
        }
        private void HandleRootMenuType()
        {
            if (this.RootMenuInstance is HorizontalMenu)
            {
                _classHelper.AddCustomClass(_inlineHorClassName);
            }
            else if (this.RootMenuInstance is InlineMenu inline)
            {
                if (inline.Collapsed)
                {
                    _classHelper.AddCustomClass(_verticalSubClassName);
                }
                else
                {
                    _classHelper.AddCustomClass(_inlineSubClassName);
                }
            }

        }
        private async void OnMouseOver()
        {
            _inThisElementScope = true;


            _classHelper
                .AddCustomClass(_openClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                .AddCustomClass(_activeClassName);
            HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
                .RemoveCustomClass(_hideDivClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                .Build();
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper
                .RemoveCustomClass(_hidULClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                .Build();

            //if (string.IsNullOrWhiteSpace(HideSubMenuDivStyle))
            //{
            if (RootMenuInstance is HorizontalMenu)
            {
                var elementInfo = await ElementHelper.GetElementRectsByID($"{IdentityKey}_mainli");
                HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Left}px").AddCustomStyle("top", $"{elementInfo.Bottom + 2}px").Build();
                HideSubMenuULStyle = _hideSubMenuULStyle.AddCustomStyle("min-width", $"{elementInfo.Width}px").Build();
            }
            else if (RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed)
            {
                if (ParentSubmenu == null)
                {
                    var windowSize = await JSRT.InvokeAsync<WindowSize>("WaveBlazor.GetWindowSize");
                    var elementInfo = await ElementHelper.GetElementRectsByID($"{IdentityKey}_mainli");
                    var ulInfo = await ElementHelper.GetElementRectsByID($"{IdentityKey}_subul");
                    var topValue = ((elementInfo.Y + ulInfo.Height) > windowSize.InnerSize.Height)? elementInfo.Bottom-ulInfo.Height: elementInfo.Y;
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{topValue}px").Build();
                }
                else
                { 
                    var elementInfo = await ElementHelper.GetElementRectsByID($"{IdentityKey}_mainli"); 
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{(elementInfo.Height < 44 ? 44 : elementInfo.Height > 100 ? 100 : elementInfo.Height)}px").Build();
                }
            }
            //}
            this.Flush();
        }

        private void OnMouseClick()
        {
            if (this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
            {
                return;
            }
            _classHelper
                .TakeInverse(_openClassName);
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper
                .AddCustomClass(_inlineClassName)
                 .TakeInverse(_hidULClassName)
                .Build();
        }

        private void OnMouseOut()
        {
            _inThisElementScope = false;
            Task.Run(async () =>
            {
                Task.Delay(100).Wait();
                if (_inThisElementScope)
                {
                    return;
                }
                _classHelper
                .RemoveCustomClass(_openClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                .RemoveCustomClass(_activeClassName);
                HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
                    .AddCustomClass(_hideDivClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                    .Build();
                HideSubMenuULClassName = _hideSubMenuULClassNameHelper
                    .AddCustomClass(_hidULClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
                    .Build();
                this.Flush();
            });
        }

    }
}
