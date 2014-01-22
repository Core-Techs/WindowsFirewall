using System;
using NetFwTypeLib;

namespace CoreTechs.WindowsFirewall.WebService
{
    /// <summary>
    /// Can be used on XP+ but not recommended on Vista+
    /// Does behave differently on new OS's that support multiple profiles. (seems to affect only domain profile)
    /// </summary>
    public class OldApi : IWinFirewallApi
    {
        public static Type FwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr");

        public void SetRemoteAddressesForRule(int port, string name, string addresses)
        {
            var fwMgr = (INetFwMgr)Activator.CreateInstance(FwMgrType);

            var item = fwMgr.LocalPolicy.CurrentProfile.GloballyOpenPorts
                .Item(port, NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP);

            item.RemoteAddresses = addresses;
        }
    }
}