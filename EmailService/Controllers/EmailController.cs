using EmailService.Contracts;
using EmailService.Entities;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace EmailService.Controllers
{
    [ApiController]
    [Route("api")]
    public class EmailController :  ControllerBase
    {
        private readonly IEmailRepository _eRepo;
        public EmailController(IEmailRepository eRepo)
        {
            _eRepo = eRepo;

        }


        [HttpPost("SendEmail")]
        public IActionResult SendEmail([FromBody] SendEmail se)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(se.From));

                email.ReplyTo.Add(MailboxAddress.Parse(se.From));

                if (!string.IsNullOrEmpty(se.To))
                {
                    string[] ToMuliId = se.To.Split(',');
                    foreach (string ToEMailId in ToMuliId)
                    {
                        email.To.Add(MailboxAddress.Parse(ToEMailId)); //adding multiple TO Email Id  
                    }
                }

                if (!string.IsNullOrEmpty(se.Cc))
                {
                    string[] CCId = se.Cc.Split(',');
                    foreach (string CCEmail in CCId)
                    {
                        email.Cc.Add(MailboxAddress.Parse(CCEmail)); //Adding Multiple CC email Id  
                    }
                }

                if (!string.IsNullOrEmpty(se.Bcc))
                {
                    string[] bccid = se.Bcc.Split(',');

                    foreach (string bccEmailId in bccid)
                    {
                        email.Bcc.Add(MailboxAddress.Parse(bccEmailId)); //Adding Multiple BCC email Id  
                    }
                }


                email.Subject = se.Subject;

                BodyBuilder builder = new BodyBuilder();
                builder.HtmlBody = se.Body;
                builder.TextBody = se.Body;

                email.Body = builder.ToMessageBody();
                int x = int.TryParse(ConfigurationManager.AppSettings["Port"], out x) ? x : 0;
                SmtpClient smtp = new SmtpClient();
                smtp.Connect(ConfigurationManager.AppSettings["Host"],x, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(ConfigurationManager.AppSettings["Username"], ConfigurationManager.AppSettings["Password"]);

                smtp.Send(email);
                smtp.Disconnect(true);

                return Ok();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }




    }
}
