using BookStore.DBOperations;
using System.Linq;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _context;

        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == BookId);//Linq
            if (book == null)
                throw new System.Exception("Silinecek kitap bulunamadı");

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
