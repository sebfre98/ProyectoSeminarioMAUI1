using SQLiteDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLiteDemo.Services
{
    public interface IMateriaService
    {
        Task<List<MateriaModel>> GetMateriaList();
        Task<int> AddMateria(MateriaModel materiaModel);
        Task<int> DeleteMateria(MateriaModel materiaModel);
        Task<int> UpdateMateria(MateriaModel materiaModel);
    }
}
