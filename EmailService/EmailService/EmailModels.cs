using Microsoft.Graph;


namespace EmailService
{
    public class EmailRequest
    {
        public string FromEmail { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
        public string BodyHtml { get; set; }
        public List<Recipient> SendTo { get; set; }
        public List<Recipient> SendBCC { get; set; }
        public List<Recipient> SendCC { get; set; }
    }
    public class GraphEmailConfig
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

}
