using PetProjectC_NeuroWeb.Modules.HashModule.Core;

namespace PetProjectC_NeuroWeb.Modules.RegistrationModule.Ports
{
    public interface IUserRegistrationService
    {
        public Task UserRegistration(HttpContext context, HashSHA512 hashService);
    }
}
