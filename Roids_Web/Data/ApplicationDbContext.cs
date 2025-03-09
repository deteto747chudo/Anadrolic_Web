using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Roids_Web.Models;

namespace Roids_Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Туринабол", Price = 50.99m, ImageUrl = "https://i.ibb.co/zTf6L1ys/default.jpg" },
                new Product { Id = 2, Name = "Туринабол", Price = 50.99m, ImageUrl = "https://i.ibb.co/zTf6L1ys/default.jpg" },
                new Product { Id = 3, Name = "Туринабол", Price = 50.99m, ImageUrl = "https://i.ibb.co/zTf6L1ys/default.jpg" }
            );

            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { Id = 1, Question = "Как да се регистрирам?", Answer = "Можете да се регистрирате чрез бутона 'Регистрация' в горния десен ъгъл." },
                new FAQ { Id = 2, Question = "Как да сменя паролата си?", Answer = "Отидете в настройките на профила си и изберете 'Смяна на парола'." }
            );
        }
    }
}
