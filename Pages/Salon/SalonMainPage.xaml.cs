using ProiectMediiMobile1.Pages.Programare;
using ProiectMediiMobile1.Pages.Client;
namespace ProiectMediiMobile1.Pages.Salon;

public partial class SalonMainPage : ContentPage
{
    public SalonMainPage(int loggedInUserId)
    {
        InitializeComponent();
    }

    //  redirect to ProgramariListPage
    private async void OnViewProgramariClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProgramareListPage());
    }

    //  redirect to ClientListPage
    private async void OnViewClientsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ClientListPage());
    }

    // redirect to SalonListPage
    private async void OnViewSalonsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SalonListPage());
    }
}