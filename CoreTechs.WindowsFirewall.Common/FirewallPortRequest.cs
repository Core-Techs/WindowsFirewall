namespace CoreTechs.WindowsFirewall.Common
{
    public class FirewallPortRequest
    {
        public int Port { get; set; }
        public string Name { get; set; }
        public string RemoteAddresses { get; set; }
    }
}