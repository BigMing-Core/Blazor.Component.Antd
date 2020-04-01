using LuanNiao.Blazor.Core;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd.Button
{
    public partial class LNButton : LNBCBase
    {
        public enum LBtnType
        {
            Primary,
            Dashed,
            Link
        }

        public enum LBtnSize
        {
            Large,
            Middle,
            Small
        }

        [Parameter]
        public LBtnSize? BtnSize { get; set; }

        [Parameter]
        public LBtnType? BtnType { get; set; }
         

        public LNButton()
        {
            _classHelper.SetStaticClass("ant-btn");
        }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();
            HandleType();
            HandleSize();

        }
        private void HandleType()
        {
            if (BtnType!=null)
            {
                switch (BtnType.Value)
                {
                    case LBtnType.Primary:
                        _classHelper.AddCustomClass("ant-btn-primary");
                        break;
                    case LBtnType.Dashed:
                        _classHelper.AddCustomClass("ant-btn-dashed");
                        break;
                    case LBtnType.Link:
                        _classHelper.AddCustomClass("ant-btn-link");
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleSize()
        {
            if (BtnSize!=null)
            {
                switch (BtnSize.Value)
                {
                    case LBtnSize.Large:
                        _classHelper.AddCustomClass("ant-btn-lg");
                        break; 
                    case LBtnSize.Small:
                        _classHelper.AddCustomClass("ant-btn-sm");
                        break;
                    case LBtnSize.Middle:
                    default:
                        break;
                }
            }
        }

    }
}
