namespace ObiletCase.Core.Settings
{
    public class SessionSetting
    {
        public int Type { get; set; }
        public ConnectionSetting Connection { get; set; }
        public BrowserSetting Browser { get; set; }
    }
    public class ConnectionSetting
    {
        public string IpAddress { get; set; }
        public string Port { get; set; }
    }

    public class BrowserSetting
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }
}