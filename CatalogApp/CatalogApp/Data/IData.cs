using SQLite;

namespace CatalogApp.Data
{
    public interface IData
    {
        SQLiteAsyncConnection GetConnection();
    }
}