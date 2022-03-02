using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;

namespace Semester_Project_0._1.Utility
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient("99f18d20f96811575978218e030ac0f6", "075a866ff68215031253c858dd5c7f71")
            {

            };


            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "project.class.schedule@gmail.com")
               .Property(Send.FromName, "Class Scheduler")
               .Property(Send.Subject, subject)
               .Property(Send.TextPart, "Dear ")
               .Property(Send.HtmlPart, htmlMessage)
               .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", email}
                 }
                   });
            MailjetResponse response = await client.PostAsync(request);







            /*MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
     new JObject {
      {
       "From", new JObject {
        {"Email", "project.class.schedule@gmail.com"},
        {"Name", "Paddy"}
       }
      }, {
       "To", new JArray {
        new JObject {
         {
          "Email", email}, 
            {
          "Name", "Paddy"
         }
        }
       }
      }, {
       "Subject", subject}, {
       "TextPart",
       "My first Mailjet email"
      }, {
       "HTMLPart", htmlMessage
      }, {
       "CustomID",
       "AppGettingStartedTest"
      }
     }
             });
            MailjetResponse response = await client.PostAsync(request);*/
        }
    }
}
