using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Puzzle.Scripts.UI
{
    public class Placeholder : MonoBehaviour, IDropHandler
    {
        public event Action<int, int> PieceWasMoved;

        public void OnDrop(PointerEventData eventData)
        {
            GameObject dropped = eventData.pointerDrag;
            DragAbleItem dragAbleItem = dropped.GetComponent<DragAbleItem>();
            dragAbleItem.ParentAfterDrag = transform;

            dropped.GetComponent<Transform>().position = GetComponent<Transform>().position;
            PieceWasMoved?.Invoke(int.Parse(gameObject.name), int.Parse(dragAbleItem.gameObject.name));
        }
    }
}