using Microsoft.EntityFrameworkCore;
using Strore.Models;
using Store.Models;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Store.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(WebApplication app) //(IApplicationBuilder app)
        {
            using var scope = app.Services.CreateScope();
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                new Product
                {
                    Name = "Intel Core i5 11400F",
                    Description = "2.6 ГГц и 4.4 ГГц в режиме Turbo",
                    Category = "Процессоры",
                    Price = 12490m
                },
                new Product
                {
                    Name = "Intel Core i3 10100F",
                    Description = "3.6 ГГц и 4.3 ГГц в режиме Turbo",
                    Category = "Процессоры",
                    Price = 5590m
                },
                new Product
                {
                    Name = "AMD Ryzen 7 5800X",
                    Description = "3.8 ГГц и 4.7 ГГц в режиме Turbo",
                    Category = "Процессоры",
                    Price = 21990m
                },
                new Product
                {
                    Name = "AMD Athlon 200GE",
                    Description = "3.2 ГГц",
                    Category = "Процессоры",
                    Price = 4690m
                },
                    new Product
                    {
                        Name = "Palit NVIDIA GeForce RTX 2060SUPER",
                        Description = "8ГБ GDDR6, 14000МГц",
                        Category = "Видеокарты",
                        Price = 29990m
                    },
                    new Product
                    {
                        Name = "Palit NVIDIA GeForce RTX 3050",
                        Description = "8ГБ GDDR6, 14000МГц",
                        Category = "Видеокарты",
                        Price = 24590m
                    },
                    new Product
                    {
                        Name = "Palit NVIDIA GeForce RTX 3060Ti",
                        Description = "8ГБ GDDR6, 14000МГц",
                        Category = "Видеокарты",
                        Price = 36490
                    },
                    new Product
                    {
                        Name = "GIGABYTE AMD Radeon RX 6500XT",
                        Description = "4ГБ GDDR6, 18000МГц",
                        Category = "Видеокарты",
                        Price = 19990
                    },
                    new Product
                    {
                        Name = "Palit NVIDIA GeForce GTX 1050TI",
                        Description = "4ГБ GDDR5, 7000МГц",
                        Category = "Видеокарты",
                        Price = 13490
                    },
                    new Product
                    {
                        Name = "Palit NVIDIA GeForce GTX 1650",
                        Description = "4ГБ GDDR6, 12000МГц",
                        Category = "Видеокарты",
                        Price = 14290
                    },
                    new Product
                    {
                        Name = "ASUS PRIME H510M-K",
                        Description = "Сокет: LGA 1200; чипсет: Intel H510;",
                        Category = "Материнские платы",
                        Price = 5990m
                    },
                    new Product
                    {
                        Name = "GIGABYTE GA-A320M-H",
                        Description = "Сокет: SocketAM4; чипсет: AMD A320;",
                        Category = "Материнские платы",
                        Price = 4790m
                    },
                    new Product
                    {
                        Name = "GIGABYTE H510M H",
                        Description = "Сокет: LGA 1200; чипсет: Intel H510;",
                        Category = "Материнские платы",
                        Price = 5090
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
