using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.UI.Panels.Level.View;

namespace App.Scripts.UI.Panels.Level.Controller
{
    public class LevelPanelController : PanelController
    {
        public LevelPanelController(LevelPanelView view)
        {
            GroupView = view;
        }
    }
}