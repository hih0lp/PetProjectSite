namespace PetProjectC_NeuroWeb.Modules.User_Module
{
    public class UserModule : IModuleRegister
    {
        public IServiceCollection RegisterService(IServiceCollection services)
        {
            return services;
        }

        //public IEndpointRouteBuilder MapEndpoint(IEndpointRouteBuilder endpoints)
        //{
        //    endpoints.MapPost("user/register");
        //}
    }
}
