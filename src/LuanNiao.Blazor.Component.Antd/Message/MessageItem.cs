using System;
using System.Collections.Generic;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd
{
    public partial class Message
    {
        public class MessageItem
        {
            public string Text { get; set; }
            public int Duration { get; set; }
            public Action OnClose { get; set; }
        }
    }
}
