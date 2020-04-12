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
        private const string _submenuUIVerticalStaticClassNameWithMenu = "ant-menu ant-menu-sub  ant-menu-vertical";
        private const string _submenuDivStaticClassNameWithMenu = "ant-menu-submenu ant-menu-submenu-popup ant-menu-light ant-menu-submenu-placement-bottomLeft";
        private const string _submenuUIVerticalStaticClassNameWithDropdown = "ant-dropdown-menu ant-dropdown-menu-sub  ant-dropdown-menu-vertical";
        private const string _submenuDivStaticClassNameWithDropdown = "ant-dropdown-menu-submenu ant-dropdown-menu-submenu-popup ant-dropdown-menu-light ant-dropdown-menu-submenu-placement-rightTop";



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




        private readonly ClassNameHelper _hideSubMenuDivClassNameHelper = new ClassNameHelper();
        private readonly ClassNameHelper _hideSubMenuULClassNameHelper = new ClassNameHelper();
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

            HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
            .SetStaticClass(_submenuDivStaticClassNameWithMenu, () => !(RootMenuInstance is DropdownMenu))
            .SetStaticClass(_submenuDivStaticClassNameWithDropdown, () => RootMenuInstance is DropdownMenu)
            .AddCustomClass(_hideDivClassName)
            .AddCustomClass(_hideDivClassName).Build();
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper
            .SetStaticClass(_submenuUIVerticalStaticClassNameWithMenu, () => !(RootMenuInstance is DropdownMenu))
            .SetStaticClass(_submenuUIVerticalStaticClassNameWithDropdown, () => RootMenuInstance is DropdownMenu)
            .AddCustomClass(_hidULClassName)
            .AddCustomClass(_hidULClassName).Build();
        }
        private void HandleRootMenuType()
        {

            if (this.RootMenuInstance is HorizontalMenu)
            {
                _classHelper.SetStaticClass("ant-menu-submenu");
                _classHelper.AddCustomClass(_inlineHorClassName);
            }
            else if (this.RootMenuInstance is InlineMenu inline)
            {
                _classHelper.SetStaticClass("ant-menu-submenu");
                if (inline.Collapsed)
                {
                    _classHelper.AddCustomClass(_verticalSubClassName);
                }
                else
                {
                    _classHelper.AddCustomClass(_inlineSubClassName);
                }
            }
            else
            {
                _classHelper.SetStaticClass("ant-dropdown-menu-submenu").AddCustomClass("ant-dropdown-menu-submenu-vertical");
            }

        }
        private async void OnMouseOver()
        {
            _inThisElementScope = true;

            /*
             I'm not sure about that the antd other type's menu's status. so write all case below.
             */
            _classHelper
                .AddCustomClass(_openClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                .AddCustomClass(_activeClassName);
            HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
                .RemoveCustomClass(_hideDivClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && !inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                .Build();
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper
                .RemoveCustomClass(_hidULClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                .Build();
            HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("opacity", "0").Build();

            if (RootMenuInstance is HorizontalMenu)
            {
                var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Left}px").AddCustomStyle("top", $"{elementInfo.Bottom + 2}px").Build();
                HideSubMenuULStyle = _hideSubMenuULStyle.AddCustomStyle("min-width", $"{elementInfo.Width}px").Build();
            }
            else if ((RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
            {
                if (ParentSubmenu == null)
                {
                    var windowSize = await WindowInfo.GetWindowSize();
                    var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                    var ulInfo = await ElementHelper.GetElementRectsByID($"subul_{IdentityKey}");

                    var topValue = ((elementInfo.Y + ulInfo.Height) > windowSize.InnerSize.Height) ? elementInfo.Bottom - ulInfo.Height : elementInfo.Y;
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{topValue}px").Build();
                }
                else
                {
                    var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{(elementInfo.Height < 44 ? 44 : elementInfo.Height > 100 ? 100 : elementInfo.Height)}px").Build();
                }
            }
            else if (RootMenuInstance is DropdownMenu)
            {
                if (ParentSubmenu == null)
                {
                    var windowSize = await WindowInfo.GetWindowSize();// JSRT.InvokeAsync<WindowSize>("LuanNiaoBlazor.GetWindowSize");
                    var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                    var ulInfo = await ElementHelper.GetElementRectsByID($"subul_{IdentityKey}");

                    var topValue = ((elementInfo.Y + ulInfo.Height) > windowSize.InnerSize.Height) ? elementInfo.Bottom - ulInfo.Height : elementInfo.Y;
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{topValue - 24/*I have no idea about this number, dropdown's top needs this 24px.*/}px").Build();
                }
                else
                {
                    var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                    HideSubMenuDivStyle = _hideSubMenuDivStyle.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{(elementInfo.Height < 44 ? 44 : elementInfo.Height > 100 ? 100 : elementInfo.Height)}px").Build();
                }
            }
            HideSubMenuDivStyle = _hideSubMenuDivStyle.RemoveCustomStyle("opacity").Build();
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
            Task.Run(() =>
            {
                Task.Delay(100).Wait();
                if (_inThisElementScope)
                {
                    return;
                }

                /*
                 I'm not sure about that the antd other type's menu's status. so write all case below.
                 */
                _classHelper
                .RemoveCustomClass(_openClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                .RemoveCustomClass(_activeClassName);
                HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
                    .AddCustomClass(_hideDivClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                    .Build();
                HideSubMenuULClassName = _hideSubMenuULClassNameHelper
                    .AddCustomClass(_hidULClassName, () => this.RootMenuInstance is HorizontalMenu || (this.RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed) || this.RootMenuInstance is DropdownMenu)
                    .Build();
                this.Flush();
            });
        }

    }
}
