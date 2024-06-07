using RcaApp.Model;
using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using RcaApp.Pages;

namespace RcaApp.Pages;

public partial class AddAvaliacaoPopup : Popup
{
    private ObservableCollection<Avaliacao> _avaliacoes;
    private int currentRating;

    public AddAvaliacaoPopup(ObservableCollection<Avaliacao> aval)
    {
        InitializeComponent();

        _avaliacoes = aval;

        this.BindingContext = App.Usuario;

        currentRating = 1;
    }

    private async void OnSaveAvaliacaoClicked(object sender, EventArgs e)
    {
        var comentario = ENTComentario.Text;
        var estrelas = currentRating;

        var novaAvaliacao = new Avaliacao
        {
            Id = Guid.NewGuid(),
            Nome = App.Usuario.Nome,
            Comentario = comentario,
            Estrelas = (int)estrelas
        };

        await App.BancoDados.AvaliacaoDataTable.salvarAvaliacao(novaAvaliacao);

        _avaliacoes.Add(novaAvaliacao);

        ENTComentario.Text = string.Empty;
        
        Close();
    }


    private void OnStarClicked(object sender, EventArgs e)
    {
        if (sender is ImageButton button)
        {
            int rating = int.Parse(button.CommandParameter.ToString());
            UpdateStarImages(rating);
            currentRating = rating;
        }
    }


    private void UpdateStarImages(int rating)
    {
        var buttons = new[] { star1, star2, star3, star4, star5 };
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Source = i < rating ? "star.svg" : "starvazio.svg";
        }
    }
}