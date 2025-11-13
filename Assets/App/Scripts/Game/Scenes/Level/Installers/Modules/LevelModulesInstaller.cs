using App.Scripts.Game.Scenes.Level.Starter;
using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using App.Scripts.Libs.UI.Panel.Manager;
using UnityEngine;

namespace App.Scripts.Game.Scenes.Level.Installers.Modules
{
    public class LevelModulesInstaller : MonoInstaller
    {
        [SerializeField] private LevelSceneStarter _starter;
        
        public override void InstallBindings(ServiceContainer container)
        {
            _starter.Construct(container.GetService<PanelManager>());
        }
    }
}