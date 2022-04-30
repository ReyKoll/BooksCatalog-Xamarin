using CatalogApp.Data;
using CatalogApp.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.Services
{
    public class BookService : IBookService
    {
        private SQLiteAsyncConnection _connection;

        public BookService(IData dataBase)
        {
            _connection = dataBase.GetConnection();
            _connection.CreateTableAsync<Book>();
        }

        public async Task AddBook(string title, string genre, int row, int shelving, int shelf)
        {
            var book = new Book
            {
                Title = title,
                Genre = genre,
                Row = row,
                Shelving = shelving,
                Shelf = shelf
            };

            await _connection.InsertAsync(book);
        }
        public async Task DeleteBook(int id)
        {
            await _connection.DeleteAsync<Book>(id);
        }

        public async Task<Book> GetBook(int id)
        {
            return await _connection.FindAsync<Book>(id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _connection.Table<Book>().ToListAsync();
        }

        public async Task UpdateBook(Book book)
        {
            await _connection.UpdateAsync(book);
        }
    }
}