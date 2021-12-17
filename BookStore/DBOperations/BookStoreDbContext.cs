using Microsoft.EntityFrameworkCore;

namespace BookStore.DBOperations
{
    public class BookStoreDbContext:DbContext
    {   //Db operasyonları için kullanılacak olan Db context
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {} //Şuan inmemory database ile çalışıyoz ama bi farkı yok normal db ile
        public DbSet<Book> Books { get; set; } //entity ekledik.
    }
}
