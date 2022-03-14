using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace DivineAcademy.Helper.EmailHelper
{
  public  class SendMail
    {
        public static bool EmailSend(String SenderEmail,String Subject, String Message,bool isBodyHtml=false)
        {
            bool status = false;
            try
            {
                String HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
                String FromEmailID = ConfigurationManager.AppSettings["MailFrom"].ToString();
                String Password = ConfigurationManager.AppSettings["Password"].ToString();
                String Port = ConfigurationManager.AppSettings["Port"].ToString();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(FromEmailID,"Divine Academy");
                mailMessage.Subject = Subject;
                mailMessage.Body = Message;
                mailMessage.IsBodyHtml = isBodyHtml;
                mailMessage.To.Add(new MailAddress(SenderEmail));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = true;
                NetworkCredential network = new NetworkCredential();
                network.UserName = mailMessage.From.Address;
                network.Password = Password;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = network;
                smtp.Port = Convert.ToInt32(Port);
                smtp.Send(mailMessage);
                return status = true;

            }
            catch(Exception ex)
            {
              string error=   ex.ToString();
                return status;
            }
            
        }

    }
}
