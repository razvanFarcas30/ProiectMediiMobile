using ProiectMediiMobile1.Models; // Import your models namespace
using System;

namespace ProiectMediiMobile1.Pages.Programare
{
    public partial class ProgramareEntryPage : ContentPage
    {
        public ProgramareEntryPage()
        {
            InitializeComponent();
            LoadSalonsAndStilists();
        }
        

        public ProgramareEntryPage(ProiectMediiMobile1.Models.Programare programare)
        {
            InitializeComponent();
            LoadSalonsAndStilists();
        }

        private async void LoadSalonsAndStilists()
        {
            // Fetch salons and stilists from the database
            var salons = await App.Database.GetSalonsAsync();
            var stilists = await App.Database.GetStilistsAsync();

            // Populate the picker items
            salonPicker.ItemsSource = salons;
            stilistPicker.ItemsSource = stilists;
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            // Create a new Programare object
            var newProgramare = new ProiectMediiMobile1.Models.Programare 
            {
                
                DataProgramarii = dataDatePicker.Date,
                Salon = salonPicker.SelectedItem as ProiectMediiMobile1.Models.Salon, // Cast selected item to Salon
                Stilist = stilistPicker.SelectedItem as ProiectMediiMobile1.Models.Stilist, // Cast selected item to Stilist
            };

            // Save the new Programare to the database
            await App.Database.SaveProgramareAsync(newProgramare);

            // Navigate back to the previous page
            await Navigation.PopAsync();
        }
    }
}
