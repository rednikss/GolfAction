using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.Libs.UI.Panel.Manager;
using App.Scripts.UI.Panels.Level.Controller;
using App.Scripts.UI.Panels.Level.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Level.Factory
{
    public class LevelPanelFactory : IFactory<LevelPanelController>
    {
        private readonly Canvas _canvas;

        private readonly LevelPanelView _viewPrefab;

        private readonly PanelManager _panelManager;
        
        public LevelPanelFactory(LevelPanelView view, Canvas canvas, PanelManager panelManager)
        {
            _canvas = canvas;
            _viewPrefab = view;
            _panelManager = panelManager;
        }
        
        public LevelPanelController Create()
        {
            var panelView = Object.Instantiate(_viewPrefab, _canvas.transform);
            var panelController = new LevelPanelController(panelView);

            panelView.CloseButton.OnClick += async () =>
            {
                await panelView.HideAnimated();
                _panelManager.RemoveActive(panelController);
            };
            
            panelView.Hide();
            
            return panelController;
        }
    }
}