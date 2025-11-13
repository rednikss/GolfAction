using App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Base;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Libs.UI.AnimatedView.CanvasGroup.Fade
{
    public class FadeCanvasGroupView : AnimatedCanvasGroupView
    {
        [SerializeField] private UnityEngine.CanvasGroup _canvasGroup;

        public override async UniTask ShowAnimated()
        {
            CurrentTween.Kill();
            
            base.Show();
            
            CurrentTween = _canvasGroup.DOFade(1, config.duration)
                .SetEase(config.inEase)
                .SetLink(gameObject);
            
            await CurrentTween.AwaitForComplete();
        }

        public override async UniTask HideAnimated()
        {
            CurrentTween.Kill();

            CurrentTween = _canvasGroup.DOFade(0, config.duration)
                .SetEase(config.outEase)
                .SetLink(gameObject);

            await CurrentTween.AwaitForComplete();
            
            base.Hide();
        }

        public override void Show()
        {
            _canvasGroup.alpha = 1;
            base.Show();
        }
        
        public override void Hide()
        {
            _canvasGroup.alpha = 0;
            base.Hide();
        }
    }
}
