using System.Collections.Generic;

namespace Generics
{
    public class MessageCollection
    {
        private List<Message> Messages;
        public bool isErrorOccured;

        public void copyFrom(MessageCollection messageCollection)
        {
            isErrorOccured = messageCollection.isErrorOccured;
            foreach (var message in messageCollection.Messages)
            {
                this.Messages.Add(message);
            }
        }
        public void addMessage(Message message)
        {
            if (message.isError)
                isErrorOccured = true;
            Messages.Add(message);
        }
    }
}
