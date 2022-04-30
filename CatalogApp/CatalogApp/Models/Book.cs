using SQLite;
namespace CatalogApp.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Row { get; set; }

        public int Shelving { get; set; }

        public int Shelf { get; set; }
    }
}