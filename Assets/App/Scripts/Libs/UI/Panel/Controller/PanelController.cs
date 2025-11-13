using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Controller
{
    public abstract class PanelController
    {
        protected AnimatedCanvasGroupView GroupView;
        
        public UniTask ShowAnimated()
        {
            return GroupView.ShowAnimated();
        }

        public UniTask HideAnimated()
        {
            return GroupView.HideAnimated();
        }

        public void Show()
        {
            GroupView.Show();
        }

        public void Hide()
        {
            GroupView.Hide();
        }

        public void Destroy()
        {
            Object.Destroy(GroupView.gameObject);
        }
    }
}