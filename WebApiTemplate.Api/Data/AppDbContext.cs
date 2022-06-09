using Microsoft.EntityFrameworkCore;
using WebApiTemplate.Api.Models;

namespace WebApiTemplate.Api.Data
{
    public class AppDbContext : DbContext
    {
        //base constructor to build the models
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        //here we list all the models that we want inside our database
        public DbSet<UserModel> User { get; set; }
    }
}
