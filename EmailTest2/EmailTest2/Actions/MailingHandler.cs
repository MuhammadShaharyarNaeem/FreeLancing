using EmailingProject.Generics;
using EmailingProject.Generics.Cache;
using EmailingProject.Models;
using System;
using System.Collections;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailingProject.Actions
{
    public class MailingHandler : ActionHandler
    {
        string Token;
        string smtpAddress = Environment.GetEnvironmentVariable("SMTPAddress");
        int portNumber = Convert.ToInt32(Environment.GetEnvironmentVariable("Port"));
        string emailFromAddress = Environment.GetEnvironmentVariable("EmailFrom");
        string password = Environment.GetEnvironmentVariable("Password");
        string subject = Environment.GetEnvironmentVariable("Subject");
        string hostUrl = Environment.GetEnvironmentVariable("HostingUrl");
        bool enableSSL = Convert.ToBoolean(Environment.GetEnvironmentVariable("EnableSSL"));
        

        public MailingHandler(MessageCollection messageCollection)
        {
            this.messageCollection = messageCollection;
        }

        internal void DoSqlAction(MailingModel request)
        {
            Token = Guid.NewGuid().ToString();
            ArrayList Params = new ArrayList()
            {
                request.ID,
                request.EmailTo,
                request.Hours,
                Token,
                false
            };

            SQLHandler sqlHandler = new SQLHandler(Params);
            sqlHandler.ExecuteNonQuery(SqlCache.GetSql("InsertMail"));


        }

        internal async Task SendEmail(MailingModel request)
        {
            try
            {
                string emailToAddress = request.EmailTo;
                string body = hostUrl + "/api/Mail?Token=" + Token;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(emailToAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception e)
            {
                messageCollection.addMessage(new Message()
                {
                    Context = "Exception",
                    ErrorCode = 1,
                    ErrorMessage = "An Exception Occured during processing: " + e.Message,
                    isError = true,
                    LogType = Enums.LogType.Exception
                });
            }
        }

        internal void DoSqlUpdateAction(string token, string EmailFrom)
        {
            
            ArrayList Params = new ArrayList()
            {
                token,
                EmailFrom
            };

            SQLHandler sqlHandler = new SQLHandler(Params);
            DataTable dt = sqlHandler.ExecuteSqlReterieve(SqlCache.GetSql("CheckToken"));
            if (dt != null && dt.Rows.Count > 0)
            {
                if (!Convert.ToBoolean(dt.Rows[0]["isUsed"]))
                {
                    sqlHandler = new SQLHandler(Params);
                    sqlHandler.ExecuteNonQuery(SqlCache.GetSql("UpdateToken"));
                }
                else
                {
                    messageCollection.addMessage(
                       new Message()
                       {
                           Context = "MailingHandler",
                           ErrorCode = 1,
                           ErrorMessage = "The Token is already Used",
                           isError = true,
                           LogType = Enums.LogType.Exception
                       });
                }
            }
            else
            {
                messageCollection.addMessage(
                    new Message()
                    {
                        Context = "MailingHandler",
                        ErrorCode = 1,
                        ErrorMessage = "There is no token with that signature",
                        isError = true,
                        LogType = Enums.LogType.Exception
                    });
            }
        }
    }
}
