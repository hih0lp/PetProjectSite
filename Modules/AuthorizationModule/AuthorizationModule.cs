using PetProjectC_NeuroWeb.Modules.AuthorizationModule.Core;

namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule
{
    public class AuthorizationModule : IModuleRegister
    {
        public IServiceCollection RegisterService(IServiceCollection services)
        {
            services.AddTransient<UserAuthorizationService>();
            return services;
        }

        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            return endpoints;
        }
    }
}
