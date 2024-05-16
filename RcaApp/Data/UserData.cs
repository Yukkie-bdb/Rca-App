using LoginAppExemplo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppExemplo.Data
{
    public class UserData
    {
        private SQLiteAsyncConnection _conexaoDB;

        public UserData(SQLiteAsyncConnection cobexaoDB) 
        {
            _conexaoDB = cobexaoDB;
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            var Lista = _conexaoDB
                .Table<Usuario>()
                .ToListAsync();
            return Lista;
        }

        public Task<Usuario> obterUsuario(string email, string senha) 
        {
            var Usuario = _conexaoDB
                .Table<Usuario>()
                .Where(u => u.Email == email && u.Senha == senha)
                .FirstOrDefaultAsync();

            return Usuario;
        }

        public Task<Usuario> obterIdUsuario(Guid id)
        {
            var Usuario = _conexaoDB
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Usuario;
        }

        public async Task<int> salvarUsuario(Usuario usuario)
        {
            var novoUsuario = await obterIdUsuario(usuario.Id);

            if(novoUsuario == null)
            {
                return await _conexaoDB.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoDB.UpdateAsync(usuario);
            }
        }

        public async Task<int> deletarUsuario(Usuario usuario)
        {
            return await _conexaoDB.DeleteAsync(usuario);
        }
    }
}
