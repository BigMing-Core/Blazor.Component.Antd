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
        private const string _subMenuDisabledClassName = "ant-dropdown-menu-submenu-disabled";
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

        private string _hideSubMenuDivStyle;
        private readonly OriginalStyleHelper _hideSubMenuDivStyleHelper = new OriginalStyleHelper();

        private string _hideSubMenuULStyle;
        private readonly OriginalStyleHelper _hideSubMenuULStyleHelper = new OriginalStyleHelper();

        private bool _inThisElementScope = false;


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleRootMenuType();
            HandleDisable();
            HandleSubMenuChildClassInfo();
            HandleCurrentKeyValue();
            HandleMenuDefaultOpenkeys();
        }

        /// <summary>
        /// just handle in the inline menu
        /// </summary>
        private void HandleMenuDefaultOpenkeys()
        {
            if (RootMenuInstance is InlineMenu && RootMenuInstance.DefaultOpenKeys.Contains(Key))
            {
                OnMouseClick();
            }
        }

        private void HandleDisable()
        {
            _classHelper.AddCustomClass(_subMenuDisabledClassName, () => this.Disabled);
        }

        /// <summary>
        /// use to set the submenu's popup div and ul's default class info
        /// </summary>
        private void HandleSubMenuChildClassInfo()
        {
            HideSubMenuDivClassName = _hideSubMenuDivClassNameHelper
            .SetStaticClass(_submenuDivStaticClassNameWithMenu, () => !(RootMenuInstance is DropdownMenu))
            .SetStaticClass(_submenuDivStaticClassNameWithDropdown, () => RootMenuInstance is DropdownMenu)
            .AddCustomClass(_hideDivClassName).Build();
            HideSubMenuULClassName = _hideSubMenuULClassNameHelper
            .SetStaticClass(_submenuUIVerticalStaticClassNameWithMenu, () => !(RootMenuInstance is DropdownMenu))
            .SetStaticClass(_submenuUIVerticalStaticClassNameWithDropdown, () => RootMenuInstance is DropdownMenu)
            .AddCustomClass(_hidULClassName).Build();
        }

        private void HandleCurrentKeyValue()
        {
            if (string.IsNullOrWhiteSpace(Key))
            {
                Key = $"lnSubMenu_{RootMenuInstance.GetMyID()}";
            }
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
            if (this.Disabled)
            {
                return;
            }
            _inThisElementScope = true;


            ShowSubMenuDiv();
            _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper.AddCustomStyle("opacity", "0").Build();

            if (RootMenuInstance is HorizontalMenu)
            {
                await HandleHorizontalMenuCase();
            }
            else if ((RootMenuInstance is InlineMenu inlineMenu && inlineMenu.Collapsed))
            {
                await HandleInlineMenuCase();
            }
            else if (RootMenuInstance is DropdownMenu dropdownMenu)
            {
                await HandleInDropdownMenuCase(dropdownMenu);
            }
            _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper.RemoveCustomStyle("opacity").Build();
            this.Flush();
        }

        private void ShowSubMenuDiv()
        {
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
        }

        private async Task HandleHorizontalMenuCase()
        {

            var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
            _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper.AddCustomStyle("left", $"{elementInfo.Left}px").AddCustomStyle("top", $"{elementInfo.Bottom + 2}px").Build();
            _hideSubMenuULStyle = _hideSubMenuULStyleHelper.AddCustomStyle("min-width", $"{elementInfo.Width}px").Build();
        }

        private async Task HandleInlineMenuCase()
        {
            if (ParentSubmenu == null)
            {
                var windowSize = await WindowInfo.GetWindowSize();
                var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                var ulInfo = await ElementHelper.GetElementRectsByID($"subul_{IdentityKey}");

                var topValue = ((elementInfo.OffsetTop + ulInfo.Height) > windowSize.OuterHeight) ? elementInfo.OffsetTop - ulInfo.Height+elementInfo.Height : elementInfo.OffsetTop;
                _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{topValue}px").Build();
            }
            else
            {
                var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper.AddCustomStyle("left", $"{elementInfo.Width + 2}px").AddCustomStyle("top", $"{(elementInfo.Height < 44 ? 44 : elementInfo.Height > 100 ? 100 : elementInfo.Height)}px").Build();
            }
        }

        private async Task HandleInDropdownMenuCase(DropdownMenu dropdownMenu)
        {

            if (ParentSubmenu == null)
            {
                var windowSize = await WindowInfo.GetWindowSize();
                var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                var dropDownRectInfo = await dropdownMenu.GetMainElementRects();
                var ulInfo = await ElementHelper.GetElementRectsByID($"subul_{IdentityKey}");

                var topValue = elementInfo.Y - dropDownRectInfo.Y;
                _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper
                    .AddCustomStyle("left", $"{elementInfo.Width + 2}px")
                    .AddCustomStyle("top", $"{topValue}px")
                    .Build();
            }
            else
            {
                var elementInfo = await ElementHelper.GetElementRectsByID($"mainli_{IdentityKey}");
                _hideSubMenuDivStyle = _hideSubMenuDivStyleHelper
                    .AddCustomStyle("left", $"{elementInfo.Width + 2}px")
                    .AddCustomStyle("top", $"{(elementInfo.Height < 44 ? 44 : elementInfo.Height > 100 ? 100 : elementInfo.Height)}px")
                    .Build();
            }
        }

        private void OnMouseClick()
        {
            if (this.Disabled)
            {
                return;
            }
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

        private async Task OnMouseOut()
        {
            if (this.Disabled)
            {
                return;
            }
            _inThisElementScope = false;
            await Task.Run(async () =>
            {
                await Task.Delay(100);
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
