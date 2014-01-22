using System;
using NetFwTypeLib;

namespace CoreTechs.WindowsFirewall.WebService
{
    /// <summary>
    /// Can be used and recommended for Vista+ 
    /// </summary>
    public class NewApi : IWinFirewallApi
    {
        public static Type FwPolicy2Type = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");

        public void SetRemoteAddressesForRule(int port, string name, string addresses)
        {
            var fwPolicy = (INetFwPolicy2)Activator.CreateInstance(FwPolicy2Type);
            var item = fwPolicy.Rules.Item(name);

            item.RemoteAddresses = addresses;
        }
    }
}