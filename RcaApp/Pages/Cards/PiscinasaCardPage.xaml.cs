namespace RcaApp.Pages.Cards;

public partial class PiscinaCardPage : ContentPage
{
    public PiscinaCardPage()
    {
        InitializeComponent();
    }

    private void BTNBack_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void BTNIconMenuInferiorHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }

    private void BTNIconMenuInferiorLaje_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LajePage());
    }

    private void BTNIconMenuInferiorInfo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InfoPage());
    }
}