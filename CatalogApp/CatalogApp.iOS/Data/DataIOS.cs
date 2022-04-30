using CatalogApp.Data;
using CatalogApp.iOS.Data;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataIOS))]

namespace CatalogApp.iOS.Data
{
    public class DataIOS : IData
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "BooksCatalog.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}