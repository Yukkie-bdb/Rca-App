
namespace RcaApp.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();



    }
    private async void BTNEntar_Clicked(object sender, EventArgs e)
    {
        string email = TXTEmail.Text;
        string senha = TXTSenha.Text;

        if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(senha))
        {
            var usuario = await App.BancoDados.UserDataTable.obterUsuario(email, senha);

            if (usuario != null)
            {
                await Navigation.PushAsync(new HomePage());
                App.Usuario = usuario;
            }
            else
            {
                await DisplayAlert("Erro", "Usuário ou senha inválidos", "OK");
                return;
            }
        }
        else
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                await DisplayAlert("Erro", "Preencha o campo de e-mail", "OK");
            }
            else if (string.IsNullOrWhiteSpace(senha))
            {
                await DisplayAlert("Erro", "Preencha o campo de senha", "OK");
            }
        }
    }

    private async void BTNRegistar_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditUserPage());
    }
}