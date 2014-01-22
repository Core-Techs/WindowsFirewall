namespace CoreTechs.WindowsFirewall.WebService
{
    public interface IWinFirewallApi
    {
        void SetRemoteAddressesForRule(int port, string name, string addresses);
    }
}