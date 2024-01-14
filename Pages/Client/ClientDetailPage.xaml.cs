namespace ProiectMediiMobile1.Pages.Client;

public partial class ClientDetailPage : ContentPage
{
    private ProiectMediiMobile1.Models.Client currentClient;

    public ClientDetailPage(ProiectMediiMobile1.Models.Client client)
    {
        InitializeComponent();
        currentClient = client;
        BindingContext = currentClient;
    }

    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientEntryPage(currentClient));
    }

    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        bool isUserConfirmed = await DisplayAlert("Sterge Client", "Esti sigur ca vrei sa stergi acest client?", "Da", "Nu");

        if (isUserConfirmed)
        {
            await App.Database.DeleteClientAsync(currentClient);
            await Navigation.PopAsync();
        }
    }
}