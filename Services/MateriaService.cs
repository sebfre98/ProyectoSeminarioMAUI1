
using SQLite;
using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Services
{
    public class MateriaService : IMateriaService
    {
        private SQLiteAsyncConnection _dbConnection;

        private async Task SetUpDb()
        {
            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Student.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<MateriaModel>();
            }
        }

        public async Task<int> AddMateria(MateriaModel materiaModel)
        {
            await SetUpDb();
            return await _dbConnection.InsertAsync(materiaModel);
        }

        public async Task<int> DeleteMateria(MateriaModel materiaModel)
        {
            await SetUpDb();
            return await _dbConnection.DeleteAsync(materiaModel);
        }

        public async Task<List<MateriaModel>> GetMateriaList()
        {
            await SetUpDb();
            var materiaList = await _dbConnection.Table<MateriaModel>().ToListAsync();
            return materiaList;
        }

        public async Task<int> UpdateMateria(MateriaModel materiaModel)
        {
            await SetUpDb();
            return await _dbConnection.UpdateAsync(materiaModel);
        }
    }
}