
using RcaApp.Pages.Cards;

namespace RcaApp.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void BTNBack_Clicked(object sender, EventArgs e)
    {

    }

    private void BTNAccount_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Acount());
    }

    private void BTNTellIcon_Clicked(object sender, EventArgs e)
    {
        try
        {
            string phoneNumber = "5514997075223"; // Substitua pelo número de telefone que você deseja discar
            PhoneDialer.Open(phoneNumber);
        }
        catch (ArgumentNullException)
        {
            // Número de telefone inválido
            DisplayAlert("Erro", "Número de telefone inválido.", "OK");
        }
        catch (FeatureNotSupportedException)
        {
            // Ligação telefônica não suportada neste dispositivo
            DisplayAlert("Erro", "Ligação telefônica não suportada neste dispositivo.", "OK");
        }
        catch (Exception ex)
        {
            // Outro erro ocorreu
            DisplayAlert("Erro", $"Erro desconhecido: {ex.Message}", "OK");
        }
    }

    private void BTNFaceIcon_Clicked(object sender, EventArgs e)
    {
        string facebookUrl = "https://www.facebook.com/EmpreiraaRCA/?locale=pt_BR";
        Browser.OpenAsync(facebookUrl, BrowserLaunchMode.SystemPreferred);
    }

    private void BTNZapIcon_Clicked(object sender, EventArgs e)
    {
        string phoneNumber = "5514997075223";
        string whatsappUrl = $"https://wa.me/{phoneNumber}";
        Browser.OpenAsync(whatsappUrl, BrowserLaunchMode.SystemPreferred);
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
        Navigation.PushModalAsync(new AvaliacoesPage());
        //Navigation.PushAsync(new InfoPage());
    }

    private void BTNCardCalçada_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CalçadaCardPage());
    }

    private void BTNCardReforma_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ReformaCardPage());

    }
    private void BTNCardMuros_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MurosCardPage());

    }
    private void BTNCardEletrica_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EletricaCardPage());

    }
    private void BTNCardPiscinas_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PiscinaCardPage());

    }
    private void BTNCardAcabamento_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AcabamentoCardPage());

    }

    private void BTNAvaliacao_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new AvaliacoesPage());
    }
}