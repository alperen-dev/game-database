using System;
using m335.Models;
using Xamarin.Forms;
using System.Collections.Generic;

namespace m335.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class GameEntryPage : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadNote(value);
            }
        }

        public GameEntryPage()
        {
            InitializeComponent();
			
            // Set the BindingContext of the page to a new Note.
            BindingContext = new m335c();
        }

        async void LoadNote(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                m335c m = await App.Database.GetNoteAsync(id);
            }
            catch (Exception)
            {
                await DisplayAlert("ERROR", "Etwas ist beim laden schief gelaufen!", "O. K.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e) {
            var m = (m335c)BindingContext;
            m.Date = ApplyDate.Date;
            try {
                if (!string.IsNullOrWhiteSpace(m.Text) || !string.IsNullOrWhiteSpace(m.Dev)) {
                    await DisplayAlert("Meldung", "Das Spiel wurde erfolgreich hinzugefügt!", "O. K.");
                    ApplyDate.Date = DateTime.Now;
                    await App.Database.SaveNoteAsync(m);
                }
            }
            catch (Exception ex) {
                await DisplayAlert("ERROR", "Das Spiel konnte nicht hinzugefügt werden.", "O. K.");
            }

            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var m = (m335c)BindingContext;
            await App.Database.DeleteNoteAsync(m);
            await DisplayAlert("Meldung", "Das Spiel wurde erfolgreich gelöscht!", "O. K.");
            // Navigate backwards
            await Shell.Current.GoToAsync("..");
        }
    }
}