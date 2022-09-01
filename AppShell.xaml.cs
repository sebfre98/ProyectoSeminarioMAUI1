using SQLiteDemo.Views;

namespace SQLiteDemo;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        //Estudiantes
        Routing.RegisterRoute(nameof(AddUpdateStudentDetail), typeof(AddUpdateStudentDetail));
        //Materias
        Routing.RegisterRoute(nameof(AddUpdateMateriaDetail), typeof(AddUpdateMateriaDetail));
    }
}
