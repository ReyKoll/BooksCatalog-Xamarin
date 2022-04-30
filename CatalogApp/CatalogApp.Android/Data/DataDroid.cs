using CatalogApp.Droid.Data;
using CatalogApp.Data;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataDroid))]

namespace CatalogApp.Droid.Data
{
    public class DataDroid : IData
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "BooksCatalog.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}