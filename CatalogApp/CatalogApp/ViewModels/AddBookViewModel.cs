using CatalogApp.Services;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatalogApp.ViewModels
{
    [QueryProperty(nameof(Title), nameof(Title))]
    public class AddBookViewModel : BaseViewModel
    {
        string title, genre;
        int id, row, shelving, shelf;

        public int ID { get => id; set => SetValue(ref id, value); }
        public string Title { get => title; set => SetValue(ref title, value); }
        public string Genre { get => genre; set => SetValue(ref genre, value); }
        public int Row { get => row; set => SetValue(ref row, value); }
        public int Shelving { get => shelving; set => SetValue(ref shelving, value); }
        public int Shelf { get => shelf; set => SetValue(ref shelf, value); }

        public ICommand SaveCommand { get; }

        IBookService bookService;

        public AddBookViewModel()
        {
            SaveCommand = new Command(async () => await Save());
            bookService = DependencyService.Get<IBookService>();
        }

        private async Task Save()
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(genre))
                return;

            await bookService.AddBook(title, genre, row, shelving, shelf);

            await Shell.Current.GoToAsync("..");
        }
    }
}
