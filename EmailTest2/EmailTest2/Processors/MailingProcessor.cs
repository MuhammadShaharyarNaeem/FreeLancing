using EmailingProject.Actions;
using EmailingProject.Generics;
using EmailingProject.Models;
using System.Threading.Tasks;

namespace EmailingProject.Processors
{
    public class MailingProcessor : Processor
    {
        ValidationHandler validationHandler = new ValidationHandler();
        public MailingProcessor(MessageCollection messageCollection) : base(messageCollection)
        {
            validationHandler.messageCollection = this.messageCollection;
        }

        public async Task SendMail(MailingModel request)
        {
            validationHandler.CheckNull(request.EmailTo, "Email Address");
            validationHandler.CheckNull(request.ID.ToString(), "ID");
            validationHandler.CheckNull(request.Hours.ToString(), "Hours");
            
            if (!messageCollection.isErrorOccured)
            {
                MailingHandler handler = new MailingHandler(messageCollection);
                handler.DoSqlAction(request);
                
                if (!messageCollection.isErrorOccured)
                {
                    await handler.SendEmail(request);
                }
            }
        }
        public async Task ReceiveToken(string Token, string EmailFrom)
        {
            validationHandler.CheckNull(Token, "Token");
            
            if (!messageCollection.isErrorOccured)
            {
                MailingHandler handler = new MailingHandler(messageCollection);
                handler.DoSqlUpdateAction(Token,EmailFrom);

            }
        }
        
    }
}
