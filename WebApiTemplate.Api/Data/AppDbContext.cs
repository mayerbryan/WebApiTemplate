using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Models;

namespace WebApiTemplate.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserModel> User { get; set; }
    }
}
