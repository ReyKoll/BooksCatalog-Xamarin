using CatalogApp.Services;
using System;

using Xamarin.Forms;

namespace CatalogApp.Views
{
    [QueryProperty(nameof(ID), nameof(ID))]
    public partial class DetailsPage : ContentPage
    {
        public string ID { get; set; }

        IBookService bookService;

        public DetailsPage()
        {
            InitializeComponent();
            bookService = DependencyService.Get<IBookService>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(ID, out var result);

            BindingContext = await bookService.GetBook(result);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}