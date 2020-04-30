using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd
{
    public partial class Message
    {

        private readonly ObservableCollection<MessageItem> _messages = new ObservableCollection<MessageItem>();
        public ObservableCollection<MessageItem> Messages { get => _messages; }

        private LNMessageStub _currentStub = null;
        public LNMessageStub CurrentStub
        {
            get => _currentStub;
            internal set
            {
                _currentStub = value;
                value.Disposing += (() =>
                {
                    if (_currentStub == value)
                    {
                        _currentStub = null;
                    }
                });
            }
        }
        public  Message Chain(MessageItem item)
        {
            lock (_messages)
            {
                _messages.Add(item);
            }
            item.Wait();
            return this;
        }
        public Message Show(MessageItem item)
        {
            lock (_messages)
            {
                _messages.Add(item);
            }
            return this;
        }
    }
}
