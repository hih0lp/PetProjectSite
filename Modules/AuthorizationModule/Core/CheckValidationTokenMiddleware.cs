namespace PetProjectC_NeuroWeb.Modules.AuthorizationModule.Core
{
    public class CheckValidationTokenMiddleware
    {
        public CheckValidationTokenMiddleware(RequestDelegate next) 
        {
            _next = next;
        }

        private readonly RequestDelegate _next;


    }
}
