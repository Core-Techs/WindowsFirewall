using CoreTechs.WindowsFirewall.Common;
using FluentValidation;

namespace CoreTechs.WindowsFirewall.WebService
{
    class FirewallPortRequestValidator : AbstractValidator<FirewallPortRequest>
    {
        public FirewallPortRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.RemoteAddresses).NotEmpty();
            RuleFor(x => x.Port).InclusiveBetween(0, 65535);
        }
    }
}