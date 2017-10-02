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

        private static volatile Email _instance;
        private static readonly object SyncRoot = new Object();
        private Email() { }

        public static Email Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (SyncRoot)
                {
                    if (_instance == null)
                        _instance = new Email();
                }
                return _instance;
            }
        }

        public void SendMail(string mensaje, string asunto, string to)
        {
            MailMessage mail = new MailMessage("uciricardopalma@gmail.com", to);
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            
            client.Credentials = new NetworkCredential("uciricardopalma@gmail.com", "uci101010");
            try
            {
                client.Send(mail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
