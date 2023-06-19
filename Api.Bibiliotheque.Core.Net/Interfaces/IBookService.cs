using Api.Bibiliotheque.Core.Net.Models;

namespace Api.Bibiliotheque.Core.Net.Interfaces
{
    public interface IBookService
    {
        Task<List<BookModel>> GetBooks();
        Task<BookModel?> GetBook(int id);
        Task<BookModel> AddBook(BookModel book);
        Task<BookModel?> UpdateBook(int id, BookModel book);
        Task<BookModel?> DeleteBook(int id);

    }
}
