using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaUtil
{
    public class Email
    {
        public void sendMail(string mensaje, string asunto)
        {
            MailMessage mail = new MailMessage("you@yourcompany.com", "user@hotmail.com");
            mail.Subject = asunto;
            mail.Body = mensaje;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.googlemail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("myemail@gmail.com", "password");
            client.Send(mail);

        }
    }
}
