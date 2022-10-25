using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Autodesk.Revit.DB;
using RevitModeless.Core;

namespace RevitModeless.ViewModels;

public sealed class RevitModelessViewModel : ObservableObject
{
    private readonly ExternalEvent _externalEvent;

    public RelayCommand DeleteCommand { get; }

    private void Delete()
    {
     _externalEvent.Raise();
     Console.WriteLine();
    }

    public RevitModelessViewModel(UIDocument uiDocument)
    {
        DeleteCommand = new RelayCommand(Delete);
        _externalEvent = ExternalEvent.Create(new DeleteHandler());
    }
}