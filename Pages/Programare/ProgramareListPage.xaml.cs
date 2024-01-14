namespace ProiectMediiMobile1.Pages.Programare;

public partial class ProgramareListPage : ContentPage
{
    public ProgramareListPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProgramari();
    }

    private async void LoadProgramari()
    {
        List<ProiectMediiMobile1.Models.Programare> programari = await App.Database.GetProgramariAsync();
        programareListView.ItemsSource = programari;
    }

    private async void OnAddProgramareClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramareEntryPage());
    }

    private async void OnProgramareSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem is ProiectMediiMobile1.Models.Programare selectedProgramare)
        {
            await Navigation.PushAsync(new ProgramareDetailPage(selectedProgramare));
            programareListView.SelectedItem = null;
        }
    }
}