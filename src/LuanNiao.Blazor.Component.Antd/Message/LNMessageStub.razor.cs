using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LuanNiao.Blazor.Component.Antd
{
    public partial class LNMessageStub
    {
        [Inject]
        public Message MessageInstance { get; set; }


        protected override void OnInitialized()
        {
            MessageInstance.Messages.CollectionChanged += _messages_CollectionChanged;
            MessageInstance.CurrentStub = this;
            base.OnInitialized();
        }

        private void _messages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    Task.Run(async () =>
                    {
                        var itemInstance = (item as Message.MessageItem);
                        await Task.Delay(itemInstance.Duration);
                        if (itemInstance.Removing)
                        {
                            return;
                        }
                        itemInstance.Removing = true;

                        this.Flush();
                        await Task.Delay(1000);
                        lock (MessageInstance.Messages)
                        {
                            MessageInstance.Messages.Remove(itemInstance);
                        }
                    });
                }
            }
            this.Flush();
        }
    }
}
