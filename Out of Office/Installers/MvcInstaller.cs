using Application;
using Infrastructure;
using OutOfOffice.Installers;

namespace Out_of_Office.Installers;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure();
        services.AddApplication();
        services.AddAuthorization();
    }
}