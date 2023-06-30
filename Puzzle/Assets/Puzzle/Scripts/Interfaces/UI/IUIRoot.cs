using UnityEngine;


namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IUIRoot
    {
        public Transform WorldspaceCanvas { get; }

        public RectTransform OverlayCanvas { get; }
    }
}