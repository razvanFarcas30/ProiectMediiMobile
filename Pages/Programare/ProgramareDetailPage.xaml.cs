namespace ProiectMediiMobile1.Pages.Programare
{
    public partial class ProgramareDetailPage : ContentPage
    {
        private ProiectMediiMobile1.Models.Programare currentProgramare;

        public ProgramareDetailPage(ProiectMediiMobile1.Models.Programare programare)
        {
            InitializeComponent();
            currentProgramare = programare;
            BindingContext = currentProgramare;
        }

        private async void OnEditButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProgramareEntryPage(currentProgramare));
        }

        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            bool isUserConfirmed = await DisplayAlert("Sterge Programare", "Esti sigur ca vrei sa stergi aceasta programare?", "Da", "Nu");

            if (isUserConfirmed)
            {
                await App.Database.DeleteProgramareAsync(currentProgramare);
                await Navigation.PopAsync();
            }
        }
    }
}
