using System.Collections.Generic;
using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Controller;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Manager
{
    public class PanelManager
    {
        private readonly List<IFactory<PanelController>> _factories;

        private readonly List<PanelController> _activePanels = new();
        
        public PanelManager(List<IFactory<PanelController>> factories)
        {
            _factories = factories;
        }

        public TController GetPanel<TController>() where TController : PanelController
        {
            foreach (var panel in _activePanels)
            {
                if (panel.GetType() != typeof(TController)) continue;
                
                return (TController)panel;
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

        public void SetActive(PanelController panel)
        {
            _activePanels.Add(panel);
        }
        
        public PanelController GetActive()
        {
            return _activePanels.Count == 0 ? null : _activePanels[^1];
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