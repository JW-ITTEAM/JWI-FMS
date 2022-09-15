using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.Data;

namespace FMS_API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<T_USER>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;                
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager<SignInManager<T_USER>>();

            services.AddAuthentication();
            return services;
        }
    }
}
