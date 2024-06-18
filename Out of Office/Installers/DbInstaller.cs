
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace OutOfOffice.Installers;

public class DbInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OutOfOfficeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("OutOfOfficeCS")));
    }
}
