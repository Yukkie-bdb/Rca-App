using RcaApp.Model;

namespace RcaApp.Pages;

public partial class Acount : ContentPage
{
    Usuario _usuario;

    public Acount()
    {
        InitializeComponent();

        _usuario = App.Usuario;

        this.BindingContext = _usuario;

        TXTBemVindo.Text = $"Seja Bem-Vindo {App.Usuario.Nome}! ";
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

