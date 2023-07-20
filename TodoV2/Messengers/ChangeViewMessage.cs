using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoV2.Messengers
{

    public sealed class ChangeViewMessage : ValueChangedMessage<string>
    {
        public ChangeViewMessage(string value) : base(value)
        {
        }
    }
}
