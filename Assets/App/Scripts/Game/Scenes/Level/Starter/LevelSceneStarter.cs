using App.Scripts.Libs.Infrastructure.Core.EntryPoint.MonoInitializable;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Level.Factory;
using UnityEngine;

namespace App.Scripts.Game.Scenes.Level.Starter
{
    public class LevelSceneStarter : MonoInitializable
    {
        private PanelManager _panelManager;
        
        public void Construct(PanelManager panelManager)
        {
            _panelManager = panelManager;
        }
        
        public override async void Init()
        {
            var panelFactory = _panelManager.GetFactory<LevelPanelFactory>();
            var panel = panelFactory.Create();
            _panelManager.SetActive(panel);
            
            await panel.ShowAnimated();
            
            Debug.Log("PLAY!!!");
        }
    }
}