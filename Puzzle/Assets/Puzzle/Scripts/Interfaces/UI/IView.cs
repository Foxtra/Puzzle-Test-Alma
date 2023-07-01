using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IView
    {
        public void SetRoot(RectTransform canvas);
        public void Enable();
        public void Disable();
    }
}