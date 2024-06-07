using RcaApp.Model;
using System.Collections.ObjectModel;
using RcaApp.Pages.Cards;

namespace RcaApp.Pages;

public partial class HomePage : ContentPage
{
    private ObservableCollection<Avaliacao> _avaliacoes;
    public HomePage()
    {
        InitializeComponent();

        _avaliacoes = new ObservableCollection<Avaliacao>();

        AvaliacoesCollectionView.ItemsSource = _avaliacoes;

        CarregarAvaliacoes();
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

    private async void CarregarAvaliacoes()
    {
        var avaliacoesList = await App.BancoDados.AvaliacaoDataTable.GetAvaliacoesAsync();
        _avaliacoes.Clear();

        foreach (var avaliacao in avaliacoesList)
        {
            _avaliacoes.Add(avaliacao);
        }

        SLAvaliacaoVazia.IsVisible = _avaliacoes.Count == 0;
    }

    private void OnAddAvaliacaoClicked(object sender, EventArgs e)
    {
        AddAvaliacaoLayout.IsVisible = true;
    }

    private async void OnSaveAvaliacaoClicked(object sender, EventArgs e)
    {
        var comentario = ENTComentario.Text;
        var estrelas = int.Parse(ENTEstrelas.Text);

        var novaAvaliacao = new Avaliacao
        {
            Id = Guid.NewGuid(),
            Nome = App.Usuario.Nome,
            Comentario = comentario,
            Estrelas = estrelas
        };

        await App.BancoDados.AvaliacaoDataTable.salvarAvaliacao(novaAvaliacao);

        _avaliacoes.Add(novaAvaliacao);
        AddAvaliacaoLayout.IsVisible = false;
        SLAvaliacaoVazia.IsVisible = false;
        ENTComentario.Text = string.Empty;
        ENTEstrelas.Text = string.Empty;
    }

    private async void BTNDeletarAvaliacao_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var avaliacao = button?.CommandParameter as Avaliacao;

        if (avaliacao != null)
        {
            var confirm = await DisplayAlert("Confirmar Exclusão", "Você deseja deletar esta avaliação?", "Sim", "Não");
            if (confirm)
            {
                await App.BancoDados.AvaliacaoDataTable.deletarAvaliacao(avaliacao);
                _avaliacoes.Remove(avaliacao);
                SLAvaliacaoVazia.IsVisible = _avaliacoes.Count == 0;
            }
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Avaliacao é nulo.");
        }
    }
}