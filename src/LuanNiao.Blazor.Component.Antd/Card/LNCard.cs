using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd.Card
{
    public partial class LNCard
    {

        private const string _staticClassName = "ant-card";
        private const string _borderedClassName = "ant-card-bordered";


        public LNCard()
        {
            _classHelper.SetStaticClass(_staticClassName);
        }


        [Parameter]
        public bool Bordered { get; set; } = true;

        [Parameter]
        public RenderFragment Title { get; set; }

        [Parameter]
        public RenderFragment Extra { get; set; }

        [Parameter]
        public IList<RenderFragment> Actions { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            HandleBordered();
        }


        private void HandleBordered()
        {
            _classHelper.AddCustomClass(_borderedClassName, () => Bordered);
        }
    }
}
