using AutoMapper;
using BookStore.BookOperations.GetBookDetail;
using BookStore.BookOperations.GetBooks;
using static BookStore.BookOperations.CreateBook.CreateBookCommand;

namespace BookStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();//CreatebookModel objesi book objesine maplenebilir oldu
            CreateMap<Book, BookDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
            CreateMap<Book,BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }
    }
}
