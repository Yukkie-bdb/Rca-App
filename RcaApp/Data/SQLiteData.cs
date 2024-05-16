using LoginAppExemplo.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginAppExemplo.Data
{
    public class SQLiteData
    {
        readonly SQLiteAsyncConnection _conexaoDB;

        public UserData UserDataTable { get; set; }

        public SQLiteData(string path) 
        {
            _conexaoDB = new SQLiteAsyncConnection(path);
            _conexaoDB.CreateTableAsync<Usuario>().Wait();

            UserDataTable = new UserData(_conexaoDB);
        }
    }
}
