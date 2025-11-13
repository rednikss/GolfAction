using App.Scripts.Libs.UI.AnimatedView.Config;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base
{
    public abstract class AnimatedCanvasGroupView : MonoBehaviour
    {
        [SerializeField] protected ConfigAnimation config;

        protected Tween CurrentTween;
        
        public abstract UniTask ShowAnimated();
        
        public abstract UniTask HideAnimated();

        public virtual void Show()
        {
            transform.SetAsLastSibling();
            gameObject.SetActive(true);
        }
        
        public virtual void Hide()
        {
            transform.SetAsFirstSibling();
            gameObject.SetActive(false);
        }
    }
}