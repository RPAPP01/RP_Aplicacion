using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;


namespace App_RP.DataBaseLocal
{
    public class RP_DataBase
    {
        readonly SQLiteAsyncConnection _database;

        public RP_DataBase(string dbPath)
        {


            //Establece Conexion
            _database = new SQLiteAsyncConnection(dbPath);
            //Elimina Tabla
            _database.DropTableAsync<Perfil>().Wait();
            //Crea Tabla 
            _database.CreateTableAsync<Perfil>().Wait();
           
        }

        //-----------------------------------------------------------------
        //--------Config
        public Task<List<Perfil>> GetPerfilAsync()
        {
            return _database.Table<Perfil>().ToListAsync();
        }
        public Task<int> SavePerfilgAsync(Perfil contact)
        {
            return _database.InsertAsync(contact);
        }

        public Task<int> DeletePerfilAsync(Perfil contact)
        {
            return _database.DeleteAsync(contact);
        }
        public Task<int> UpdatePerfilAsync(Perfil contact)
        {
            return _database.UpdateAsync(contact);
        }
    }
}
