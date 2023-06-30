using System;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;


namespace Assets.Puzzle.Scripts.UI
{
    public class ViewFactory : IViewFactory
    {
        private ISystemResourceManager _resourceManager;
        private IUIRoot _uiRoot;

        public ViewFactory(ISystemResourceManager resourceManager, IUIRoot uiRoot)
        {
            _resourceManager = resourceManager;
            _uiRoot = uiRoot;
        }

        public T CreateView<T, E>(E item)
            where T : IView
            where E : Enum
        {
            var viewObj = _resourceManager.CreatePrefabInstance<T, E>(item);
            viewObj.SetRoot(_uiRoot.OverlayCanvas);

            return viewObj;
        }
    }
}