using Microsoft.AspNetCore.Components;
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
            public int Duration { get; set; } = 1000 * 3;
            public Action OnClose { get; set; }
            public bool Removing { get; set; }
            public RenderFragment Icon { get; set; }
            public RenderFragment Content { get; set; }

            public string ClassName
            {
                get
                {
                    return $"ant-message-notice {(Removing ? "move-up-leave move-up-leave-active" : "")}";
                }
            }
            public MessageItemType MessageType { get; set; } = MessageItemType.Success;
            public string MessageTypeClassName
            {
                get
                {
                    return $"ant-message-custom-content ant-message-{MessageType.ToString().ToLower()}";
                }

            }
        }

        public enum MessageItemType
        {
            Success,
            Error,
            Info,
            Warning,
            Loading,
            Normal
        }
    }
}
