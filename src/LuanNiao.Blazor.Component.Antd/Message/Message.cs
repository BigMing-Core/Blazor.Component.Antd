using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LuanNiao.Blazor.Component.Antd
{
    public partial class Message
    {

        internal readonly ObservableCollection<MessageItem> _messages = new ObservableCollection<MessageItem>(); 

        public void Success(MessageItem item)
        {
            _messages.Add(item);
        }
    }
}
