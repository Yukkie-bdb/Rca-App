using RcaApp.Model;

namespace RcaApp.Pages;

public partial class EditUserPage : ContentPage
{
    Usuario _usuario;
    public EditUserPage()
    {
        _usuario = new Usuario();

        this.BindingContext = _usuario;

        InitializeComponent();


    }

    private async void BTNCadastar_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(_usuario.Email) && string.IsNullOrEmpty(_usuario.Senha) && string.IsNullOrEmpty(_usuario.Nome))
        {
            await DisplayAlert("Erro", "Preencha todas as informações", "Fechar");
            return;
        }

        var cadastro = await App.BancoDados.UserDataTable.salvarUsuario(_usuario);

        if (cadastro > 0)
        {
            await DisplayAlert("Sucesso", "Usuário cadastrado com sucesso", "Fechar");
            await Navigation.PopAsync();
        }

    }

    private async void BTNVoltar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void BTNLogin_Clicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }


}