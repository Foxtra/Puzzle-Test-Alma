using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;

namespace Assets.Puzzle.Scripts.Interfaces.GameManagement
{
    public interface IWorkflow 
    {
        public IModel GetNextModel(IGameManager gameManager, IViewFactory viewFactory,
            ISystemResourceManager resourceManager, ModelParameters parameters);
    }
}