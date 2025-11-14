using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace App.Scripts.Libs.UI.Elements.SwipeHandler
{
    public class SwipeHandler : Selectable, IDragHandler
    {
        public Vector2 Swipe;

        private Vector2 _swipeStartPoint;

        private Camera _activeCamera;
        
        public void Construct(Camera activeCamera)
        {
            _activeCamera = activeCamera;
        }
        
        public override void OnPointerDown(PointerEventData eventData)
        {
            _swipeStartPoint = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Swipe = GetSwipeVector(_swipeStartPoint, eventData.position);
            Debug.Log(Swipe);
        }

        private Vector2 GetSwipeVector(Vector2 pixelStartPosition, Vector2 pixelEndPosition)
        {
            // var startPos = _activeCamera.ScreenToWorldPoint(pixelEndPosition);
            // var endPos = _activeCamera.ScreenToWorldPoint(pixelStartPosition);

            var posDelta = pixelEndPosition - pixelStartPosition;
            posDelta *= _activeCamera.orthographicSize * 2 / _activeCamera.pixelHeight;
            
            return posDelta;
        }
    }
}