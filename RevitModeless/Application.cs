using Nice3point.Revit.Toolkit.External;
using RevitModeless.Commands;

namespace RevitModeless;

[UsedImplicitly]
public class Application : ExternalApplication
{
    public override void OnStartup()
    {
        CreateRibbon();
    }

    private void CreateRibbon()
    {
        var panel = Application.CreatePanel("Panel name", "RevitModeless");

        var showButton = panel.AddPushButton<Command>("Button text");
        showButton.SetImage("/RevitModeless;component/Resources/Icons/RibbonIcon16.png");
        showButton.SetLargeImage("/RevitModeless;component/Resources/Icons/RibbonIcon32.png");
    }
}