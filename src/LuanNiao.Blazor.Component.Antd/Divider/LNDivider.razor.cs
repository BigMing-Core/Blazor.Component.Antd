using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Divider
{
    public partial class LNDivider
    {
        public enum OrientationType
        {
            Center,
            Left,
            Right
        }
        private const string _staticClassName = "ant-divider";
        private const string _staticVerticalClassName = "ant-divider-vertical";
        private const string _staticHorizontalClassName = "ant-divider-horizontal";
        private const string _staticDashedClassName = "ant-divider-dashed";
        private const string _staticRightOr = "ant-divider-with-text-right";
        private const string _staticLeftOr = "ant-divider-with-text-left";
        private const string _staticCenterOr = "ant-divider-with-text-center";


        public LNDivider()
        {
            ClassHelper.SetStaticClass(_staticClassName);
        }

        [Parameter]
        public bool IsVertical { get; set; }
        [Parameter]
        public OrientationType? Orientation { get; set; } = null;
        [Parameter]
        public bool Dashed { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleIsVertical();
            HandleOrientation();
            HandleDashed();
        }

        private void HandleDashed()
        {
            ClassHelper.AddCustomClass(_staticDashedClassName, () => Dashed);
        }

        private void HandleOrientation()
        {
            if (Orientation == null)
            {
                return;
            }

            switch (Orientation.Value)
            {
                case OrientationType.Center:
                    ClassHelper.AddCustomClass(_staticCenterOr);
                    break;
                case OrientationType.Left:
                    ClassHelper.AddCustomClass(_staticLeftOr);
                    break;
                case OrientationType.Right:
                    ClassHelper.AddCustomClass(_staticRightOr);
                    break;
            }
        }

        private void HandleIsVertical()
        {
            ClassHelper
                .AddCustomClass(_staticVerticalClassName, () => IsVertical)
                .AddCustomClass(_staticHorizontalClassName, () => !IsVertical);
        }

    }
}
