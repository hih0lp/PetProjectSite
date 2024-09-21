using PetProjectC_NeuroWeb.Modules.UserModule.UserModule;
using PetProjectC_NeuroWeb.Modules.UserModule.UserModule.Ports;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.Run();
