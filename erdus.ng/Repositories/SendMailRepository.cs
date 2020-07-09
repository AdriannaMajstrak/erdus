using erdus.ng.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polly;
using System;

namespace erdus.ng.Repositories
{
    public class SendMailRepository : ISendMessageRepository
    {
        private readonly SmtpSettings _smtpOptions;
        private readonly ILogger<SendMailRepository> _logger;

        public SendMailRepository(IOptions<SmtpSettings> options, ILogger<SendMailRepository> logger)
        {
            _smtpOptions = options.Value;
            _logger = logger;
        }

        public void SendMessage(string sender, string[] recipents, string topic, string content)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(_smtpOptions.SmtpServer, int.Parse(_smtpOptions.SmtpPort));
                client.UseDefaultCredentials = true;
                client.Credentials = new System.Net.NetworkCredential(_smtpOptions.SmtpUser, _smtpOptions.SmtpPassword);
                client.EnableSsl = true;
                client.Timeout = 5000;

                Policy
                  .Handle<Exception>()
                  .WaitAndRetry(8, retryAttempt => TimeSpan.FromMinutes(Math.Pow(2, retryAttempt)), (e, r) =>
                  {
                      _logger.LogWarning($"Cannot send email. System will retry it. Details: {e}");
                  })
                  .Execute(() =>
                  {
                      client.Send(sender, string.Join(',', recipents), topic, content);
                      _logger.LogInformation("Email has been sent");
                  });
            }
            catch (Exception e)
            {
                _logger.LogError($"Cannot send email. System will not retry it. Details: {e}");
                throw;
            }
        }
    }
}
