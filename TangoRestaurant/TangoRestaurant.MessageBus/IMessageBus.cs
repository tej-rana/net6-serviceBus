using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TangoRestaurant.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage(BaseMessage message, string topicName);
    }
}
