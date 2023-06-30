using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Puzzle.Scripts.UI
{
    public class DragAbleItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;
        private Transform _InitialParent;
        private Vector2 _initialAnchoredPosition;

        private float _scaleFactor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _scaleFactor = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>().scaleFactor;
            _InitialParent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            _initialAnchoredPosition = _rectTransform.anchoredPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
        }

        public void ResetPosition()
        {
            _rectTransform.anchoredPosition = _initialAnchoredPosition;
            transform.SetParent(_InitialParent);
        }
    }
}