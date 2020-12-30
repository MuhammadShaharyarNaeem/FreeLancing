using EmailingProject.Generics;
using EmailingProject.Models;
using EmailingProject.Processors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EmailingProject.Controllers
{
    [ApiController]
    
    public class MailController : Generics.Controller
    {
        IConfiguration Config;
        string SqlConnectionString;
        public MailController(IConfiguration configuration)
        {
            Config = configuration;
            SqlConnectionString = Config.GetConnectionString("DefaultConnection");

        }
        [HttpPost]
        [Route("api/AuthMail")]
        public async Task<JsonResult> Post([FromBody] MailingModel Request)
        {
            try
            {
                MailingProcessor processor = new MailingProcessor(messageCollection);
                await processor.SendMail(Request);

                if (messageCollection.isErrorOccured)
                {
                    foreach (var message in messageCollection.Messages)
                    {
                        if (message.isError)
                        {
                            Response.StatusCode = 400;
                            return new JsonResult(HttpStatusCode.BadRequest, message);
                        }
                        else
                        {
                            Response.StatusCode = 500;
                            return new JsonResult(HttpStatusCode.InternalServerError);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return new JsonResult(new Message()
                { 
                    Context = "Exception",
                    ErrorCode = 1,
                    ErrorMessage ="An Exception Occured during processing: " + e.Message,
                    isError = true,
                    LogType = Enums.LogType.Exception
                });
            }
            return new JsonResult(HttpStatusCode.OK,"Suceess");
        }

        [HttpGet]
        [Route("api/AuthMail")]
        public async Task<JsonResult> Get([FromQuery] string Token, [FromQuery] string EmailFrom)
        {
            try
            {
                MailingProcessor processor = new MailingProcessor(messageCollection);
                await processor.ReceiveToken(Token,EmailFrom);
                
                if (messageCollection.isErrorOccured)
                {
                    foreach (var message in messageCollection.Messages)
                    {
                        if (message.isError)
                        {
                            return new JsonResult(HttpStatusCode.BadRequest, messageCollection.Messages[0].ErrorMessage);
                        }
                        else
                        {
                            return new JsonResult(HttpStatusCode.InternalServerError);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                return new JsonResult(HttpStatusCode.InternalServerError, "An Exception Occured" + e.Message);
            }
            return new JsonResult(HttpStatusCode.OK);
        }
    }
}
