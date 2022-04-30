using CatalogApp.Models;
using CatalogApp.Services;
using CatalogApp.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CatalogApp.ViewModels
{
    public class CatalogViewModel : BaseViewModel
    {
        private IBookService bookService;

        public ObservableCollection<Book> Book { get; set; }

        public ICommand AddCommand { get; }
        public ICommand SelectCommand { get; }
        public ICommand DeleteCommand { get; }

        string title, genre;
        int id, row, shelving, shelf;

        public int ID { get => id; set => SetValue(ref id, value); }
        public string Title { get => title; set => SetValue(ref title, value); }
        public string Genre { get => genre; set => SetValue(ref genre, value); }
        public int Row { get => row; set => SetValue(ref row, value); }
        public int Shelving { get => shelving; set => SetValue(ref shelving, value); }
        public int Shelf { get => shelf; set => SetValue(ref shelf, value); }

        public CatalogViewModel()
        {
            Book = new ObservableCollection<Book>();

            AddCommand = new Command(async () => await Add());
            SelectCommand = new Command(async () => await Select());
            DeleteCommand = new Command(async () => await Delete());

            bookService = DependencyService.Get<IBookService>();
        }

        private async Task Add()
        {
            var route = $"{nameof(AddBookPage)}";

            await Shell.Current.GoToAsync(route);
        }

        private async Task Select()
        {
            if (Book == null)
                return;

            var route = $"{nameof(CatalogPage)}?BookID={ID}";

            await Shell.Current.GoToAsync(route);
        }

        private async Task Delete()
        {
            await bookService.DeleteBook(id);

            await Shell.Current.GoToAsync("..");
        }
    }
}