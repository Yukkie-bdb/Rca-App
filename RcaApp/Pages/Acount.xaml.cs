using RcaApp.Model;

namespace RcaApp.Pages;

public partial class Acount : ContentPage
{
    private Usuario _usuario;

    public Acount()
    {
        InitializeComponent();

        _usuario = App.Usuario;

        this.BindingContext = _usuario;

        TXTBemVindo.Text = $"Seja Bem-Vindo {App.Usuario.Nome}! ";

        fotoPerfil.Clicked += async (sender, e) =>
        {
            if (MediaPicker.IsCaptureSupported)
            {
                var file = await MediaPicker.PickPhotoAsync();
                if (file != null)
                {
                    var filePath = file.FullPath;

                    fotoPerfil.Source = ImageSource.FromFile(filePath);

                    _usuario.Foto = filePath;
                    await App.BancoDados.UserDataTable.salvarUsuario(_usuario);

                }
            }
        };


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

    private async void BTNSalvarAcc_Clicked(object sender, EventArgs e)
    {
        await App.BancoDados.UserDataTable.salvarUsuario(_usuario);
    }
}

