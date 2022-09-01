using SQLiteDemo.ViewModels;

namespace SQLiteDemo.Views;

public partial class MateriaListPage : ContentPage
{
    private MateriaListPageViewModel _viewMode;
    public MateriaListPage(MateriaListPageViewModel viewModel)
	{
		InitializeComponent();
        _viewMode = viewModel;
        this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewMode.GetMateriaListCommand.Execute(null);
    }
}