namespace ProiectMediiMobile1.Pages.Programare;

public partial class ProgramareMainPage : ContentPage
{
    public ProgramareMainPage()
    {
        InitializeComponent();
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ProiectMediiMobile1.Models.Programare)BindingContext;
        //slist.Data = DateTime.UtcNow;
        await App.Database.SaveProgramareAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ProiectMediiMobile1.Models.Programare)BindingContext;
        await App.Database.DeleteProgramareAsync(slist);
        await Navigation.PopAsync();
    }
}