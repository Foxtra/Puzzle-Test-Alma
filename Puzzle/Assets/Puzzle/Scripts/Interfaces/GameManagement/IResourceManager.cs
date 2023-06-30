using Assets.Puzzle.Scripts.Interfaces.UI;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.GameMagagement
{
    public interface IResourceManager
    {
        public Camera CreateCamera();
        public IUIRoot CreateUIRoot(Camera worldSpaceCamera);
    }
}
