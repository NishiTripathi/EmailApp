using EmailApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Net.Mail;


namespace EmailApp.Controllers
{
    [Route("api")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        [HttpPost("send")]
        public ActionResult sendMail(Email email)
        {
            string To = email.To;
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("nishitripathi98@gmail.com");
            mailMessage.To.Add(To);
            mailMessage.Subject = "No-Reply Mail";
            mailMessage.Body = "Sending Link";
            mailMessage.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("nishitripathi98@gmail.com", "password");
            smtp.Send(mailMessage);
            return Ok();
        }
    }
}
