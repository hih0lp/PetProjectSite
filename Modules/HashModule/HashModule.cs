using PetProjectC_NeuroWeb.Modules.HashModule.Core;
using PetProjectC_NeuroWeb.Modules.HashModule.Ports;

namespace PetProjectC_NeuroWeb.Modules.HashModule
{
    public class HashModule : IModuleRegister
    {
        public IServiceCollection RegisterService(IServiceCollection services)
        {
            services.AddTransient<IHashService, HashSHA512>();

            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}
