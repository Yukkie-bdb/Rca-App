using RcaApp.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcaApp.Data
{
    public class AvaliacaoData
    {
        private SQLiteAsyncConnection _conexaoDB;

        public AvaliacaoData(SQLiteAsyncConnection cobexaoDB)
        {
            _conexaoDB = cobexaoDB;
        }

        public Task<List<Avaliacao>> GetAvaliacoesAsync()
        {
            var Lista = _conexaoDB
                .Table<Avaliacao>()
                .ToListAsync();
            return Lista;
        }

        public Task<Avaliacao> obterAvaliacao(string nome, string comentario)
        {
            var Avaliacao = _conexaoDB
                .Table<Avaliacao>()
                .Where(u => u.Nome == nome && u.Comentario == comentario)
                .FirstOrDefaultAsync();

            return Avaliacao;
        }

        public Task<Avaliacao> obterIdAvaliacao(Guid id)
        {
            var Avaliacao = _conexaoDB
                .Table<Avaliacao>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Avaliacao;
        }

        public async Task<int> salvarAvaliacao(Avaliacao avaliacao)
        {
            var novoAvaliacao = await obterIdAvaliacao(avaliacao.Id);

            if (novoAvaliacao == null)
            {
                return await _conexaoDB.InsertAsync(avaliacao);
            }
            else
            {
                return await _conexaoDB.UpdateAsync(avaliacao);
            }
        }

        public async Task<int> deletarAvaliacao(Avaliacao avaliacao)
        {
            return await _conexaoDB.DeleteAsync(avaliacao);
        }
    }
}
