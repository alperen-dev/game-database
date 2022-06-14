using System;
using System.Linq;
using m335.Models;
using Xamarin.Forms;

namespace m335.Views
{
    public partial class m335Page : ContentPage
    {
        public m335Page()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage.
            await Shell.Current.GoToAsync(nameof(GameEntryPage));
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                m335c m = (m335c)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(GameEntryPage)}?{nameof(GameEntryPage.ItemId)}={m.ID.ToString()}");
            }
        }
    }
}