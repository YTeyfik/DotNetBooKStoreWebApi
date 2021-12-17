using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace BookStore.DBOperations
{
    public class DataGenerator
    {   //initial data için data generator
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using ( var context=new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;
                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1, oto increment yaptık
                        Title = "Şu Çılgın Türkler",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 02, 11)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Suç ve Ceza",
                        GenreId = 2,
                        PageCount = 250,
                        PublishDate = new DateTime(2002, 05, 12)
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Fareler ve İnsanlar",
                        GenreId = 1,
                        PageCount = 500,
                        PublishDate = new DateTime(1996, 02, 11)
                    }
                 );

                context.SaveChanges();
            }
        }
    }
}
