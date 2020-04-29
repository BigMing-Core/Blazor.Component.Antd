using Microsoft.AspNetCore.Components;

namespace LuanNiao.Blazor.Component.Antd.Input
{
    public partial class LNInputGroup
    {
        [Parameter]
        public LNInputSize Size { get; set; } = LNInputSize.Middle;

        [Parameter]
        public bool Compact { get; set; } = false;

        public LNInputGroup()
        {
            _classHelper.SetStaticClass(LNInputClassName.GroupClassName);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleSize();
            HandleCompact();
            Flush();
        }

        private void HandleSize()
        {
            switch (Size)
            {
                case LNInputSize.Large:
                    _classHelper.AddCustomClass(LNInputClassName.LargeGroupClassName);
                    break;
                case LNInputSize.Small:
                    _classHelper.AddCustomClass(LNInputClassName.SmallGroupClassName);
                    break;
            }
        }

        private void HandleCompact()
        {
            _classHelper.AddCustomClass(LNInputClassName.CompactGroupClassName, () => Compact);
        }
    }
}
