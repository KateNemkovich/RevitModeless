using RevitModeless.ViewModels;

namespace RevitModeless.Views;

public partial class RevitModelessView
{
    public RevitModelessView(RevitModelessViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}