using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Autodesk.Revit.DB;

namespace RevitModeless.ViewModels;

public sealed class RevitModelessViewModel : ObservableObject
{
    private readonly UIDocument _uiDocument;
    public RelayCommand DeleteCommand { get; }

    private void Delete()
    {
        var document = _uiDocument.Document;
        using var transaction = new Transaction(document);
        transaction.Start("Delete elements");
        //Когда получаем то, что уже выделено
        document.Delete(_uiDocument.Selection.GetElementIds());
        transaction.Commit();
    }

    public RevitModelessViewModel(UIDocument uiDocument)
    {
        _uiDocument = uiDocument;
        DeleteCommand = new RelayCommand(Delete);
    }
}