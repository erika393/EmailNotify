using System;
using System.Text;
using System.IO;  
using System.Net;  
using Newtonsoft.Json;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit.Text;
using System.Collections;

namespace NotifyLib.Notify;
    public class Notify
    {
        public void SendEmail(string sender, string passwordSender, string recipient, string subject, string message, ArrayList attachments)
        {
            //create email
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(sender));
            email.To.Add(MailboxAddress.Parse(recipient));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = message };

            //attachments
            var builder = new BodyBuilder();
            builder.TextBody = message;
            foreach(string obj in attachments){
                builder.Attachments.Add(obj);
            }
            email.Body = builder.ToMessageBody();

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtpout.secureserver.net", 465, SecureSocketOptions.Auto);
            smtp.Authenticate(sender, passwordSender);
            smtp.Send(email);
            smtp.Disconnect(true);
            
        }
    }