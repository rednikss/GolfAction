using System.Collections.Generic;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Manager
{
    public class PanelManager
    {
        private List<IFactory<PanelController>> _factories;

        private readonly List<PanelController> _activePanels = new();

        public void SetFactories(List<IFactory<PanelController>> factories)
        {
            _factories = factories;
        }
        
        public TController GetPanel<TController>() where TController : PanelController
        {
            for (var i = _activePanels.Count - 1; i > 0; i--)
            {
                var panel = _activePanels[i];
                if (panel.GetType() != typeof(TController)) continue;

                return (TController) panel;
            }

            return null;
        }

        public TFactory GetFactory<TFactory>() where TFactory : class, IFactory<PanelController>
        {
            foreach (var panelFactory in _factories)
            {
                if (panelFactory.GetType() != typeof(TFactory)) continue;
                
                return (TFactory) panelFactory;
            }

            Debug.LogError($"Attempted to create non-existent {typeof(TFactory).Name}!");

            return null;
        }

        public void AddActive(PanelController panel)
        {
            if (_activePanels.Count != 0) _activePanels[^1].SetInteractable(false);
            
            _activePanels.Add(panel);
        }
        
        public void RemoveActive(PanelController panel)
        {
            if (_activePanels.Count > 1 && _activePanels[^1] == panel)
            {
                _activePanels[^2].SetInteractable(true);
            }
            
            _activePanels.Remove(panel);
        }
        public void DestroyAll()
        {
            while (_activePanels.Count > 0)
            {
                var panel = _activePanels[0];
                _activePanels.RemoveAt(0);
                panel.Destroy();
            }
        }
    }
}