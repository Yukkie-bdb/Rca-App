namespace RcaApp.Pages;

public partial class LajePage : ContentPage
{
	public LajePage()
	{
		InitializeComponent();
	}

    private void BTNBack_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNAccount_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNTellIcon_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNFaceIcon_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNZapIcon_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNIconMenuInferiorHome_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new LajePage());
    }

    private void BTNIconMenuInferiorLaje_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new HomePage());
    }

    private void BTNIconMenuInferiorInfo_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new InfoPage());
    }

}