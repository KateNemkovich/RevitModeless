using Autodesk.Revit.Attributes;
using Nice3point.Revit.Toolkit.External;
using RevitModeless.ViewModels;
using RevitModeless.Views;
using RevitModeless.Utils;

namespace RevitModeless.Commands;

[UsedImplicitly]
[Transaction(TransactionMode.Manual)]
public class Command : ExternalCommand
{
   public override void Execute()
    {
        if (WindowController.Focus<RevitModelessView>()) return;

        var viewModel = new RevitModelessViewModel(UiDocument);
        var view = new RevitModelessView(viewModel);
        WindowController.Show(view, UiApplication.MainWindowHandle);
    }
}