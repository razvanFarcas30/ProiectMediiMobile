
namespace ProiectMediiMobile1.Pages.Salon;

public partial class SalonEntryPage : ContentPage
{
    private ProiectMediiMobile1.Models.Salon currentSalon;

    public SalonEntryPage()
    {
        InitializeComponent();
        currentSalon = new ProiectMediiMobile1.Models.Salon();
    }

    public SalonEntryPage(ProiectMediiMobile1.Models.Salon Salon)
    {
        InitializeComponent();
        currentSalon = Salon;
        LoadSalonDetails();
    }

    private void LoadSalonDetails()
    {
        numeEntry.Text = currentSalon.Nume;
        orasEntry.Text = currentSalon.Oras;
        pretEntry.Text = currentSalon.Pret;
        categorieEntry.Text = currentSalon.Categorie;



    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        currentSalon.Nume = numeEntry.Text;
        currentSalon.Oras = orasEntry.Text;
        currentSalon.Pret = pretEntry.Text;
        currentSalon.Categorie = categorieEntry.Text;


        await App.Database.SaveSalonAsync(currentSalon);
        await Navigation.PopAsync();
    }
}