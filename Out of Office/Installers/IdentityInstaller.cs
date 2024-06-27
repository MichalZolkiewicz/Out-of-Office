using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using OutOfOffice.Installers;

namespace Out_of_Office.Installers;

public class IdentityInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<OutOfOfficeContext>()
                .AddDefaultTokenProviders();
    }
}
