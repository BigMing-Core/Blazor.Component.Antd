using LuanNiao.Blazor.Core;
using LuanNiao.Blazor.Core.Common;
using LuanNiao.Blazor.Core.ElementEventHub.Attributes;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestPages.Pages
{
    public partial class EventHubTest
    {
        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
            if (firstRender)
            {
                ElementEventHub.GetElementInstance("TestInfo");
                    //.Bind(this, nameof(OnClick)
                    //, nameof(MouseOver)
                    //, nameof(MouseDown)
                    //, nameof(MouseEnter)
                    //, nameof(MouseUp)
                    //, nameof(MouseMove)
                    //, nameof(MouseOut)
                    //, nameof(ContextMenu));
                ElementEventHub.GetElementInstance("TestInfo1");
                //.Bind(this, nameof(OnClick)
                //, nameof(MouseOver1)
                //, nameof(MouseDown1)
                //, nameof(MouseEnter1)
                //, nameof(MouseUp1)
                //, nameof(MouseMove1)
                //, nameof(MouseOut1)
                //, nameof(ContextMenu1));

                ElementEventHub.GetElementInstance("input1")
                    .Bind(this
                    ,nameof(OnBlur)
                    ,nameof(OnChange)
                    , nameof(OnFocus)
                    , nameof(OnFocusIn)
                    , nameof(OnFocusOut)
                    , nameof(OnInput)
                    , nameof(OnKeyDown)
                    , nameof(OnKeypress)
                    , nameof(OnKeyup) 
                    );

                ElementEventHub.GetElementInstance("scrolltest")
                    .Bind(this, nameof(OnScroll));
            }
        }

        [OnScrollEvent]
        public void OnScroll(ElementScrollEvent scrollEvent)
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnScroll)}:{scrollEvent.ScrollTop}:{scrollEvent.ScrollHeight}");
        }

        [OnKeyDownEvent]
        public void OnKeyDown()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnKeyDown)}");
        }

        [OnKeypressEvent]
        public void OnKeypress()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnKeypress)}");
        }

        [OnKeyupEvent]
        public void OnKeyup()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnKeyup)}");
        }

        [OnBlurEvent]
        public void OnBlur()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnBlur)}");
        }

        [OnChangeEvent]
        public void OnChange()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnChange)}");
        }

        [OnFocusEvent]
        public void OnFocus()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnFocus)}");
        }


        [OnFocusInEvent]
        public void OnFocusIn()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnFocusIn)}");
        }



        [OnFocusOutEvent]
        public void OnFocusOut()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnFocusOut)}");
        }

        [OnInputEvent]
        public void OnInput()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnInput)}");
        }


      


        [OnClickEvent]
        public void OnClick(MouseEvent @event)
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnClick)}:{@event.Button}");
        }

        [OnMouseOverEvent]
        public void MouseOver()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseOver)}");
        }


        [OnMouseEnterEvent]
        public void MouseEnter()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseEnter)}");
        }


        [OnMouseDownEvent]
        public void MouseDown()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseDown)}");
        }


        [OnMouseUpEvent]
        public void MouseUp()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseUp)}");
        }


        [OnMouseMoveEvent]
        public void MouseMove()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseMove)}");
        }


        [OnMouseOutEvent]
        public void MouseOut()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseOut)}");
        }


        [OnContextMenuEvent]
        public void ContextMenu()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(ContextMenu)}");
        }





        [OnClickEvent]
        public void OnClick1(MouseEvent @event)
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(OnClick1)}:{@event.Button}");
        }

        [OnMouseOverEvent]
        public void MouseOver1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseOver1)}");
        }


        [OnMouseEnterEvent]
        public void MouseEnter1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseEnter1)}");
        }


        [OnMouseDownEvent]
        public void MouseDown1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseDown1)}");
        }


        [OnMouseUpEvent]
        public void MouseUp1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseUp1)}");
        }


        [OnMouseMoveEvent]
        public void MouseMove1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseMove1)}");
        }


        [OnMouseOutEvent]
        public void MouseOut1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(MouseOut1)}");
        }


        [OnContextMenuEvent]
        public void ContextMenu1()
        {
            Console.WriteLine($"{nameof(EventHubTest)}:{nameof(ContextMenu1)}");
        }
    }
}
