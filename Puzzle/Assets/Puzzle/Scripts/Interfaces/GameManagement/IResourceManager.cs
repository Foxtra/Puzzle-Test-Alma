using Assets.Puzzle.Scripts.Interfaces.Input;
using Assets.Puzzle.Scripts.Interfaces.UI;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.GameMagagement
{
    public interface IResourceManager
    {
        public Camera CreateCamera();
        public IInputManager CreateInputManager();
        public IUIRoot CreateUIRoot(Camera worldSpaceCamera);
    }
}
