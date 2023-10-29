using System.Text.Json.Serialization;

namespace ObiletCase.Core.Models
{
    public class SessionRequestModel
    {
        public SessionRequestModel()
        {
            Connection = new Connection();
            Browser = new Browser();
        }
        public int Type { get; set; }
        public Connection Connection { get; set; }
        public Browser Browser { get; set; }
    }
    public class Connection
    {
        [JsonPropertyName("ip-address")]
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }
    public class Browser
    {
        public string Version { get; set; }
        public string Name { get; set; }
    }
}