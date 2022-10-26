using Autodesk.Revit.UI;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Autodesk.Revit.DB;
using Nice3point.Revit.Toolkit.External;
using Nice3point.Revit.Toolkit.External.Handlers;
using RevitModeless.Core;

namespace RevitModeless.ViewModels;

public sealed class RevitModelessViewModel : ObservableObject
{
    private readonly ActionEventHandler _externalEvent;

    public RelayCommand DeleteCommand { get; }

    private void Delete()
    {
        _externalEvent.Raise(application =>
        {
            var uiDocument = application.ActiveUIDocument;
            var document = uiDocument.Document;
            using var transaction = new Transaction(document);
            transaction.Start("Delete elements");
            //Когда получаем то, что уже выделено
            document.Delete(uiDocument.Selection.GetElementIds());
            transaction.Commit();
        });
    }
    public RevitModelessViewModel(UIDocument uiDocument)
    {
        DeleteCommand = new RelayCommand(Delete);
        _externalEvent = new ActionEventHandler();
    }
}