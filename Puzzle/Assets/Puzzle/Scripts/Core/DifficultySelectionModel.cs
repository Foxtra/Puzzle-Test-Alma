using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;

namespace Assets.Puzzle.Scripts.Core
{
    public class DifficultySelectionModel : IModel
    {
        public DifficultySelectionModel(IGameManager gameManager, IViewFactory viewFactory,
           ISystemResourceManager resourceManager, ModelParameters parameters)
        {
          
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}