using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SoccerLeagueTransferApp.MuyikUtility
{
    public static class Email
    {
        //method to send email
        //takes 7 parameters(toaddress,fromaddress,subject,body,smtpserveraddress,portnumber,smtpusername and password.
        //method name is sendemail
        public static void SendEmail(String toAddress, String fromAddress, String subject, String body, String smtpServerAddress, int portNumber, String smtpUsername, String smtpPassword)
        {
            MailAddress to = new MailAddress(toAddress);//creating recipient email address
            MailAddress from = new MailAddress(fromAddress);//creating sender email address

            MailMessage message = new MailMessage(from, to);//creating a new email message
            message.Subject = subject;//assign value to the title of email
            message.Body = body;//assign value to the content of email body

            SmtpClient client = new SmtpClient(smtpServerAddress, portNumber)
            {
                Credentials = new NetworkCredential(smtpUsername.Trim(), smtpPassword.Trim()),
                EnableSsl = false
            };
            // code in brackets above needed if authentication required 

            try
            {
                client.Send(message);
            }
            catch (SmtpException)
            {

            }

        }
    }

}
