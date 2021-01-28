using microservice.Models;
namespace microservice.Services
{
    public static class DbInit
    {
        public static void initData(CatalogueDbRepository CatalogueDb){
            CatalogueDb.Categories.Add(new Category{Name="Computers"});
            CatalogueDb.Categories.Add(new Category{Name="Printers"});
            CatalogueDb.Categories.Add(new Category{Name="Scanners"});
            CatalogueDb.Products.Add(new Product{Name="Hp",Price=150,CategoryID=1});
            CatalogueDb.Products.Add(new Product{Name="Dell",Price=300,CategoryID=1});
            CatalogueDb.Products.Add(new Product{Name="Hp",Price=500,CategoryID=2});
            CatalogueDb.Products.Add(new Product{Name="Accent",Price=900,CategoryID=3});
            CatalogueDb.Clients.Add(new Client{Name="Hamza"});
            CatalogueDb.Clients.Add(new Client{Name="Maryam"});
            CatalogueDb.SaveChanges();
        }
    }
}