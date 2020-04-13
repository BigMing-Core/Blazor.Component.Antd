using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd
{

    public interface IGutter { }
    public class SameGutter : IGutter
    {
        public int Gutter { get; set; }
    }

    /*
     * ANTD V4's configinfo
     * code in \antd\lib\_util\responsiveObserve.js::14
     var responsiveMap = {
  xs: '(max-width: 575px)',
  sm: '(min-width: 576px)',
  md: '(min-width: 768px)',
  lg: '(min-width: 992px)',
  xl: '(min-width: 1200px)',
  xxl: '(min-width: 1600px)'
};
         */
    public class ResponsiveGutter : IGutter
    { 
        public int XS { get; set; }
        public int SM { get; set; }
        public int MD { get; set; }
        public int LG { get; set; }
        public int XL { get; set; }
        public int XXL { get; set; }

        private int _currentGutter = 0;

        internal void Marshal()
        {
            if (XS == 0)
            {
                XS = SM != 0 ? SM :
                    MD != 0 ? MD :
                    LG != 0 ? LG :
                    XL != 0 ? XL :
                    XXL != 0 ? XXL :
                    16;
            }
            if (SM == 0)
            {
                SM =
                    MD != 0 ? MD :
                    LG != 0 ? LG :
                    XL != 0 ? XL :
                    XXL != 0 ? XXL :
                    XS;
            }
            if (MD == 0)
            {
                MD = LG != 0 ? LG :
                    XL != 0 ? XL :
                    XXL != 0 ? XXL :
                    SM;
            }
            if (LG == 0)
            {
                LG =
                    XL != 0 ? XL :
                    XXL != 0 ? XXL :
                    MD;
            }
            if (XL == 0)
            {
                XL =
                    XXL != 0 ? XXL :
                    LG;
            }
            if (XXL == 0)
            {
                XXL = XL;
            }
        }

        public bool TryGetGutter(int width, out int newGutter)
        {
            newGutter = (width <= 575 ? XS :
                   width <= 768 ? SM :
                   width <= 992 ? MD :
                   width <= 1200 ? LG :
                   width <= 1600 ? XL :
                   XXL)/2;
            if (_currentGutter != newGutter)
            {
                _currentGutter = newGutter;
                return true;
            }
            return false;
        }
    }



    public class MarginGutter : IGutter
    {
        public int Vertial { get; set; }
        public int Horizontal { get; set; }
    }
}
