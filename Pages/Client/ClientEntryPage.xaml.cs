
namespace ProiectMediiMobile1.Pages.Client;

public partial class ClientEntryPage : ContentPage
{
    private ProiectMediiMobile1.Models.Client currentClient;

    public ClientEntryPage()
    {
        InitializeComponent();
        currentClient = new ProiectMediiMobile1.Models.Client();
    }

    public ClientEntryPage(ProiectMediiMobile1.Models.Client client)
    {
        InitializeComponent();
        currentClient = client;
        LoadClientDetails();
    }

    private void LoadClientDetails()
    {
        numeEntry.Text = currentClient.Nume;
        emailEntry.Text = currentClient.Email;

    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentClient.Nume = numeEntry.Text;
        currentClient.Email = emailEntry.Text;

        await App.Database.SaveClientAsync(currentClient);
        await Navigation.PopAsync();
    }
}