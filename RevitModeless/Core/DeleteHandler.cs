using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace RevitModeless.Core;

public class DeleteHandler:IExternalEventHandler
{
    
    public void Execute(UIApplication app)
    {
        var uiDocument = app.ActiveUIDocument;
        var document = uiDocument.Document;
        using var transaction = new Transaction(document);
        transaction.Start("Delete elements");
        //Когда получаем то, что уже выделено
        document.Delete(uiDocument.Selection.GetElementIds());
        transaction.Commit();
    }

    public string GetName()
    {
        return "DeleteHandler";
    }
}