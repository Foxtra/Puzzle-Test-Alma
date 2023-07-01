using Assets.Puzzle.Scripts.Interfaces.UI;
using UnityEngine;

namespace Assets.Puzzle.Scripts.UI
{
    public class View : MonoBehaviour, IView
    {
        public void SetRoot(RectTransform canvas) 
        {
            CanvasScaleFactor = canvas.GetComponent<Canvas>().scaleFactor;
            transform.SetParent(canvas, false);
        }

        public float CanvasScaleFactor { get; private set; }

        public void Enable() => gameObject.SetActive(true);
        public void Disable() => gameObject.SetActive(false);
    }
}