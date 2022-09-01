using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class AddUpdateMateriaDetail : ContentPage
{
    public AddUpdateMateriaDetail(AddUpdateMateriaDetailViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}