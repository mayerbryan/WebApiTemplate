using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Data;

namespace WebApiTemplate.Api.Services
{
    public static class DataBaseManagementService
    {
        public static void MigrationInitialisation(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var serviceDb = serviceScope.ServiceProvider.GetService<AppDbContext>();
                serviceDb.Database.Migrate();
            }
        }

    }
}
