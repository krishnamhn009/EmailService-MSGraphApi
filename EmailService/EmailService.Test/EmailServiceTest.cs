using System.Net.Mail;
using System.Net;
using Microsoft.Graph;

namespace EmailService.Test
{
    public class EmailServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            GraphEmailConfig emailConfig = new GraphEmailConfig()
            {
                ClientId = "{{service principal client id}}",
                ClientSecret = "{{service principal client secret}}",
                TenantId = "{{tenant id}}"
            };
            GraphEmailService graphEmailService = new GraphEmailService(emailConfig);
            EmailRequest request = new EmailRequest();
            request.BodyText = "Hi..this is testing";
            request.FromEmail = "monitoring@fulldata.nl";
            request .SendTo= new List<Recipient> { new Recipient { EmailAddress = new EmailAddress { Address = "krishnamhn009@gmail.com" } } };
            request.Subject = "Test mail using graph api";
            var result = graphEmailService.SendEmailAsync(request).Result;
            Assert.IsTrue(result.StatusCode.ToString() == HttpStatusCode.Accepted.ToString());
        }
    }
}