using CatalogApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBook(int id);

        Task AddBook(string title, string genre, int row, int shelving, int shelf);

        Task DeleteBook(int id);

        Task UpdateBook(Book book);
    }
}