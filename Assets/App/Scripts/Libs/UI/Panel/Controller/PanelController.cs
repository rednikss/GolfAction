using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.UI.Panel.Controller
{
    public abstract class PanelController
    {
        protected AnimatedCanvasGroupView GroupView;

        public void SetInteractable(bool value) => GroupView.CanvasGroup.interactable = value;
        public UniTask ShowAnimated() => GroupView.ShowAnimated();

        public UniTask HideAnimated() => GroupView.HideAnimated();

        public void Show() => GroupView.Show();

        public void Hide() => GroupView.Hide();

        public void Destroy() => Object.Destroy(GroupView.gameObject);
    }
}