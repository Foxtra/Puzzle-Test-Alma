using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Extensions;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Puzzle.Scripts.UI
{
    public class DragAbleItem : MonoBehaviour, IDragAbleItem, IBeginDragHandler, IEndDragHandler, IDragHandler
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
            _scaleFactor = GameObject.FindGameObjectWithTag(ETags.Canvas.ToStringCached()).GetComponent<Canvas>().scaleFactor;
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
            CheckOtherPiecesOverlaping();
            CheckIfOutOfScreen();
            _canvasGroup.blocksRaycasts = true;
        }
        public void ResetPosition()
        {
            _rectTransform.anchoredPosition = _initialAnchoredPosition;
            transform.SetParent(_InitialParent);
        }

        private void CheckIfOutOfScreen()
        {
            var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            if (pos.x > 1)
            {
                ResetPosition();
            }
            if (pos.x < 0)
            {
                ResetPosition();
            }
            if (pos.y > 1)
            {
                ResetPosition();
            }
            if (pos.y < 0)
            {
                ResetPosition();
            }
        }
        private void CheckOtherPiecesOverlaping()
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, Constants.OverlapRayCastRange);
            foreach (Collider2D hit in hitColliders)
            {
                if (hit.name != gameObject.name && hit.gameObject.tag == ETags.Piece.ToStringCached())
                {
                    ResetPosition();
                    break;
                }
            }
        }
    }
}