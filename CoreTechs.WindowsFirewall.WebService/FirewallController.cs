using System.Web.Http;
using CoreTechs.Logging;
using CoreTechs.WindowsFirewall.WebService.Infrastructure;

namespace CoreTechs.WindowsFirewall.WebService
{
    public class FirewallController : ApiController
    {
        private readonly IWinFirewallApi _fw;
        private readonly Logger _log;

        public FirewallController(IWinFirewallApi firewallApi, LogManager logManager)
        {
            _fw = firewallApi;
            _log = logManager.CreateLogger();
        }

        [Route("firewall/port")]
        public IHttpActionResult Post(FirewallPortRequest request)
        {
            if (!this.Validate<FirewallPortRequestValidator>(request).IsValid)
                return BadRequest(ModelState);

            _fw.SetRemoteAddressesForRule(request.Port, request.Name, request.RemoteAddresses);

            return Ok();
        }
    }
}