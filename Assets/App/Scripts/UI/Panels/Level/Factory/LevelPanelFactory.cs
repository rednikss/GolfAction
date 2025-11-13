using App.Scripts.Libs.Patterns.Factory;
using App.Scripts.UI.Panels.Level.Controller;
using App.Scripts.UI.Panels.Level.View;
using UnityEngine;

namespace App.Scripts.UI.Panels.Level.Factory
{
    public class LevelPanelFactory : IFactory<LevelPanelController>
    {
        private readonly Canvas _canvas;

        private readonly LevelPanelView _viewPrefab;
        
        public LevelPanelFactory(LevelPanelView view, Canvas canvas)
        {
            _canvas = canvas;
            _viewPrefab = view;
        }
        
        public LevelPanelController Create()
        {
            var panelView = Object.Instantiate(_viewPrefab, _canvas.transform);
            panelView.Hide();
            
            return new LevelPanelController(panelView);
        }
    }
}