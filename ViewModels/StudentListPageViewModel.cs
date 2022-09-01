﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using SQLiteDemo.Models;
using SQLiteDemo.Services;
using SQLiteDemo.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.ViewModels
{
    public partial class StudentListPageViewModel : ObservableObject
    {
        public ObservableCollection<StudentModel> Students { get; set; } = new ObservableCollection<StudentModel>();

        private readonly IStudentService _studentService;
        public StudentListPageViewModel(IStudentService studentService)
        {
            _studentService = studentService;
        }



        [ICommand]
        public async void GetStudentList()
        {
            Students.Clear();
            var studentList = await _studentService.GetStudentList();
            if (studentList?.Count > 0)
            {
                foreach (var student in studentList)
                {
                    Students.Add(student);
                }
            }
        }


        [ICommand]
        public async void AddUpdateStudent()
        {
            await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail));
        }


        [ICommand]
        public async void DisplayAction(StudentModel studentModel)
        {
            var response = await AppShell.Current.DisplayActionSheet("Seleccione", "Aceptar", null, "Editar", "Eliminar","Cancelar");
            if (response == "Editar")
            {
                var navParam = new Dictionary<string, object>();
                navParam.Add("StudentDetail", studentModel);
                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }
            else if (response == "Eliminar")
            {
                var delResponse = await _studentService.DeleteStudent(studentModel);
                if (delResponse > 0)
                {
                    await Shell.Current.DisplayAlert("El registro fue eliminado", "Eliminado", "Aceptar");
                    GetStudentList();
                }
            }
        }
    }
}
