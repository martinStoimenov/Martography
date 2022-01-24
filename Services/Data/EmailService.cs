using System;
using System.Threading.Tasks;
using Services.Data.Interfaces;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using sib_api_v3_sdk.Client;

namespace Services.Data
{
    public class EmailService : IEmailService
    {
        private readonly string apiKey;

        public EmailService(IConfiguration configuration)
        {
            apiKey = configuration.GetSection("SendinBlueAPI:APIKey").Value.ToString();
            if(Configuration.Default.ApiKey.ContainsKey("api-key") == false)
                Configuration.Default.ApiKey.Add("api-key", apiKey);
        }

        public async Task<bool> CreateContact(string email, string name)
        {
            // Send first email on subscribe (ask them to confirm if they want to subscribe with link.)
            var apiInstance = new ContactsApi();
            List<long?> listIds = new List<long?>();
            listIds.Add(2);
            var attributes = new Newtonsoft.Json.Linq.JObject();
            attributes.Add("FULLNAME", name);
            bool emailBlacklisted = false;
            bool smsBlacklisted = false;
            bool updateEnabled = false;
            try
            {
                var createContact = new CreateContact(email, attributes, emailBlacklisted, smsBlacklisted, listIds, updateEnabled, null);
                CreateUpdateContactModel result = await apiInstance.CreateContactAsync(createContact);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Send(string from, string subject, string message, string name, string to)
        {
            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(name))
                return false;

            var transactionalEmailsApi = new TransactionalEmailsApi();

            var emailModel = new SendSmtpEmail();
            emailModel.Sender = new SendSmtpEmailSender();
            emailModel.Sender.Email = from;
            emailModel.Sender.Name = name;

            emailModel.To = new List<SendSmtpEmailTo>() { new SendSmtpEmailTo(to, "Martography")};
            emailModel.ReplyTo = new SendSmtpEmailReplyTo(from, name);

            emailModel.Subject = subject;
            emailModel.TextContent = message;
            emailModel.HtmlContent = $"<html><head></head><body><p>{message}</p></body></html>";

            try
            {
                var res = await transactionalEmailsApi.SendTransacEmailAsync(emailModel);
            }
            catch (System.Exception ex)
            {
                var a = 0;
                throw;
            }

            return true;
        }
    }
}
