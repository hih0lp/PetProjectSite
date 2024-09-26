using PetProjectC_NeuroWeb.Modules.HashModule.Core;
using PetProjectC_NeuroWeb.Modules.HashModule.Ports;

namespace PetProjectC_NeuroWeb.Modules.RegistrationModule.Ports
{
    public interface IUserRegistrationService
    {
        public Task UserRegistrationAsync(HttpContext context, IHashService hashService);
    }
}
