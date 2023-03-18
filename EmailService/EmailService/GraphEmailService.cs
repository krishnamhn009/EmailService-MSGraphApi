using Azure.Identity;
using Microsoft.Graph;

namespace EmailService
{
     public class GraphEmailService
    {
        private readonly GraphEmailConfig _graphEmailConfig;

        public GraphEmailService(GraphEmailConfig graphEmailConfig)
        {
            _graphEmailConfig = graphEmailConfig;
        }

        public async Task<GraphResponse> SendEmailAsync(EmailRequest email)
        {

            ClientSecretCredential credential = new(_graphEmailConfig.TenantId, _graphEmailConfig.ClientId, _graphEmailConfig.ClientSecret);
            GraphServiceClient graphClient = new(credential);
            Message message = new()
            {
                Subject = email.Subject,
                Body = new ItemBody
                {
                    ContentType = string.IsNullOrEmpty(email.BodyText) ? BodyType.Html : BodyType.Text,
                    Content = string.IsNullOrEmpty(email.BodyText) ? email.BodyHtml : email.BodyText,
                },
                Importance = Importance.High
            };
           
            message.ToRecipients = email.SendTo;
            message.BccRecipients =email.SendBCC;
            message.CcRecipients = email.SendCC;
          
            bool saveToSentItems = true;

            var response = await graphClient.Users[email.FromEmail]
              .SendMail(message, saveToSentItems).Request().PostResponseAsync();
            return response;
        }

    }
}