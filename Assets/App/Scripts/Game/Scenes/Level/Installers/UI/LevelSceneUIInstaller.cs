using System.Collections.Generic;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Level.Factory;
using App.Scripts.UI.Panels.Level.View;
using UnityEngine;

namespace App.Scripts.Game.Scenes.Level.Installers.UI
{
    public class LevelSceneUIInstaller : MonoInstaller
    {
        [SerializeField] private LevelPanelView _levelPanelView;

        [SerializeField] private Camera sceneCamera;
        
        public override void InstallBindings(ServiceContainer container)
        {
            var uiCanvas = container.GetService<Canvas>();

            var panelManager = new PanelManager();
            
            var factoryList = new List<IFactory<PanelController>>
            {
                new LevelPanelFactory(_levelPanelView, uiCanvas, panelManager, sceneCamera)
            };

            panelManager.SetFactories(factoryList);

            container.SetServiceSelf(panelManager);
        }
    }
}