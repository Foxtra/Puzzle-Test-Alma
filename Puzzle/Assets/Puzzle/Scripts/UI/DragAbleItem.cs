using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Puzzle.Scripts.UI
{
    public class DragAbleItem : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        public Transform ParentAfterDrag;

        private RectTransform _rectTransform;
        private CanvasGroup _canvasGroup;

        private float _scaleFactor;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _scaleFactor = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>().scaleFactor;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = false;
            ParentAfterDrag = transform.parent;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            transform.SetParent(ParentAfterDrag);
        }
    }
}