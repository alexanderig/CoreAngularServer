using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreAngularServer.Models
{
    public class ApiDBContext:DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<GoodItem> GoodItems { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Seed();
        }    
    }


    public static class ModelBuilderExt
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Picture picture1 = new Picture { ID = 1, pathURL = "http://localhost:49866/Images/p1.jpg", GoodItemId = 1 };
            Picture picture2 = new Picture { ID = 2, pathURL = "http://localhost:49866/Images/p2.jpg", GoodItemId = 1 };
            Picture picture3 = new Picture { ID = 3, pathURL = "http://localhost:49866/Images/p3.png", GoodItemId = 2 };
            Picture picture4 = new Picture { ID = 4, pathURL = "http://localhost:49866/Images/p4.jpg", GoodItemId = 2 };
            Picture picture5 = new Picture { ID = 5, pathURL = "http://localhost:49866/Images/p5.jpg", GoodItemId = 3 };
            Picture picture6 = new Picture { ID = 6, pathURL = "http://localhost:49866/Images/p4.png", GoodItemId = 3 };
            Picture picture7 = new Picture { ID = 7, pathURL = "http://localhost:49866/Images/p1.jpg", GoodItemId = 4 };
            Picture picture8 = new Picture { ID = 8, pathURL = "http://localhost:49866/Images/p2.jpg", GoodItemId = 4 };
            Picture picture9 = new Picture { ID = 9, pathURL = "http://localhost:49866/Images/p3.png", GoodItemId = 5 };


            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Mobile Phones" },
                new Category { ID = 2, Name = "Mobile Sound" }
            );

                modelBuilder.Entity<GoodItem>().HasData(

                           new GoodItem { ID = 1, CategoryId = 1, PicURL = "http://localhost:49866/Images/p1.jpg", Date = DateTime.Now, Name = "Samsung A40", Description = "Black Color", Price = 144.4 },
                           new GoodItem { ID = 2, CategoryId = 1, PicURL = "http://localhost:49866/Images/p2.jpg", Date = DateTime.Now, Name = "Huawei Mate 2", Description = "Dark Red Screen", Price = 266.7 },
                           new GoodItem { ID = 3, CategoryId = 1, PicURL = "http://localhost:49866/Images/p3.jpg", Date = DateTime.Now, Name = "Iphone 5 SE", Description = "Dark Grey", Price = 350.4 },
                           new GoodItem { ID = 4, CategoryId = 1, PicURL = "http://localhost:49866/Images/p4.jpg", Date = DateTime.Now, Name = "Lg G40", Description = "Dark Red ", Price = 189.7 },
                           new GoodItem { ID = 5, CategoryId = 1, PicURL = "http://localhost:49866/Images/p5.jpg", Date = DateTime.Now, Name = "Meizu T20", Description = "White ", Price = 176.4 }

                    );
                modelBuilder.Entity<Picture>().HasData(
                                picture1, picture2, picture3, picture4, picture5, picture6, picture7, picture8, picture9
                               );
            
        }
    }
}


