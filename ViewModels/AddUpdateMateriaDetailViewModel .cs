using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    [QueryProperty(nameof(MateriaDetail), "MateriaDetail")]
    public partial class AddUpdateMateriaDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private MateriaModel _materiaDetail = new MateriaModel();

        private readonly IMateriaService _materiaService;
        public AddUpdateMateriaDetailViewModel(IMateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [ICommand]
        public async void AddUpdateMateria()
        {
            int response = -1;
            if (MateriaDetail.MateriaID > 0)
            {
                response = await _materiaService.UpdateMateria(MateriaDetail);
            }
            else
            {
                response = await _materiaService.AddMateria(new Models.MateriaModel
                {
                    
                    NomMateria = MateriaDetail.NomMateria,
                    
                });
            }

        

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Registro Guardado Exitosamente", "Guardado", "Aceptar");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error!", "El registro no fue guardado", "Aceptar");
            }
        }

    }
}
