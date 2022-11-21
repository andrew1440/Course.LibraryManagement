using LibraryManagement.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();


                // Add Customers
                var linet = new Customer { Name = "Linet Achieng" };

                var justin = new Customer { Name = "Justin Noon" };

                var willie = new Customer { Name = "Willie Parodi" };

                var leoma = new Customer { Name = "Leoma  Gosse" };


                context.Customers.Add(linet);
                context.Customers.Add(justin);
                context.Customers.Add(willie);
                context.Customers.Add(leoma);

                // Add Author
                var authorDeMarco = new Author
                {
                    Name = "M J DeMarco",
                    Books = new List<Book>()
                {
                    new Book { Title = "The Millionaire Fastlane" },
                    new Book { Title = "Unscripted" }
                }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                {
                    new Book { Title = "The 10X Rule"},
                    new Book { Title = "If You're Not First, You're Last"},
                    new Book { Title = "Sell To Survive"}
                }

                };
                var authorKiyosaki = new Author
                {
                    Name = "Robert Kiyosaki",
                    Books = new List<Book>()
                {
                    new Book { Title = "Rich Dad Poor Dad"},
                    new Book { Title = "Why A students work for C student and B students for the government"},
                }

                };

                context.Authors.Add(authorDeMarco);
                context.Authors.Add(authorCardone);
                context.Authors.Add(authorKiyosaki);

                context.SaveChanges();
            }
        }
    }
}
