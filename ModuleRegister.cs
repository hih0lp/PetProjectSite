namespace PetProjectC_NeuroWeb
{
    
}public interface IModuleRegister
{
    public IServiceCollection RegisterService(IServiceCollection services);
    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}

public static class ModuleExtensions
{
    static readonly List<IModuleRegister> registeredModules = new List<IModuleRegister>();

    public static IServiceCollection RegisterModules(this IServiceCollection services)
    {




        return services;
    }



    public static WebApplication MapEndpoints(this WebApplication app)
    {
        foreach (var module in registeredModules)
        {
            module.MapEndpoints(app);
        }
        return app;
    }


    private static IEnumerable<IModuleRegister> FindModules()
    {
        return typeof(IModuleRegister).Assembly
            .GetTypes()
            .Where(p => p.IsClass && p.IsAssignableTo(typeof(IModuleRegister)))
            .Select(Activator.CreateInstance)
            .Cast<IModuleRegister>();
    }
}


