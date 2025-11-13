using App.Scripts.Libs.Infrastructure.Core.Service.Container;
using App.Scripts.Libs.Infrastructure.Core.Service.Installer.MonoInstaller;
using UnityEngine;

namespace App.Scripts.Libs.Infrastructure.Core.ProjectContext.Installer
{
    public class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField] private Canvas projectCanvas;
        
        public override void InstallBindings(ServiceContainer container)
        {
            container.SetServiceSelf(projectCanvas);
        }
    }
}