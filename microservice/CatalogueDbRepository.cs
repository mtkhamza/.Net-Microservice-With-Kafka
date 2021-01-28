using microservice.Models;
using Microsoft.EntityFrameworkCore;
namespace microservice
{
    public class CatalogueDbRepository:DbContext{
        public DbSet<Category> Categories {get;set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public CatalogueDbRepository(DbContextOptions options):base(options){

        }
    }
}