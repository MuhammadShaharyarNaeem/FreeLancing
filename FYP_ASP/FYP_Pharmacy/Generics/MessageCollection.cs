using Logger;
using System.Collections.Generic;
using System.Security.Policy;

namespace Generics
{
    public class MessageCollection
    {
        private List<Message> Messages;
        public bool isErrorOccured;
        Logging log = new Logging();
        public void copyFrom(MessageCollection messageCollection)
        {
            isErrorOccured = messageCollection.isErrorOccured;
            foreach (var message in messageCollection.Messages)
            {
                Messages.Add(message);
            }
        }
        public void addMessage(Message message)
        {
            if (message.isError)
                isErrorOccured = true;
            Messages.Add(message);
        }

        public void PublishLog()
        {
            foreach (var item in Messages)
            {
                if (item.LogType.Equals(Enum.LogType.Functional))
                    log.LogFunction(item.Context, item.Function, item.WebPage);
                if (item.LogType.Equals(Enum.LogType.Exception))
                    log.LogErrorMessage(item.Context, item.ErrorMessage, item.ErrorCode, item.WebPage);
                if (item.LogType.Equals(Enum.LogType.Info) || item.LogType.Equals(Enum.LogType.Success))
                    log.LogInfo(item.Context, item.ErrorMessage, item.WebPage);
                if (item.LogType.Equals(Enum.LogType.Sql))
                    log.LogSql(item.Context, item.Query, item.QueryType.ToString());
            }
            log.PublishLog();
        }
    }
}
