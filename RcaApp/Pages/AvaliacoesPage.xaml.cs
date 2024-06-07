using RcaApp.Data;
using RcaApp.Model;
using System.Collections.ObjectModel;

namespace RcaApp.Pages
{
    public partial class AvaliacoesPage : ContentPage
    {
        private ObservableCollection<Avaliacao> _avaliacoes;

        public AvaliacoesPage()
        {
            InitializeComponent();

            _avaliacoes = new ObservableCollection<Avaliacao>();

            AvaliacoesCollectionView.ItemsSource = _avaliacoes;

            CarregarAvaliacoes();


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
}