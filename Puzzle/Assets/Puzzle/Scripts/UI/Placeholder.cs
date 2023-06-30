using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Puzzle.Scripts.UI
{
    public class Placeholder : MonoBehaviour, IDropHandler
    {
        public event Action<int, int> PieceWasMoved;

        private GameObject _lastDroppedItem;

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            DragAbleItem dragAbleItem = dropped.GetComponent<DragAbleItem>();
            dropped.GetComponent<Transform>().position = GetComponent<Transform>().position;

            if (_lastDroppedItem != null && _lastDroppedItem.name != dropped.name && _lastDroppedItem.transform.position == dropped.transform.position)
            {
                dragAbleItem.ResetPosition();
            }
            else
            {
                PieceWasMoved?.Invoke(int.Parse(gameObject.name), int.Parse(dropped.name));
                _lastDroppedItem = dropped;
            }
        }
    }
}