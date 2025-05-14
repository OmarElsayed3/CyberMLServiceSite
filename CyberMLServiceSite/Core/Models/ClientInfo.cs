namespace CyberMLServiceSite.Core.Models
{

    public class ClientInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string ServiceRequested { get; set; } = string.Empty;
    }

}
