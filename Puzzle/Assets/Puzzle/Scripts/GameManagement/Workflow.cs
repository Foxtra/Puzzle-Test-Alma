using Assets.Puzzle.Scripts.Core;
using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.GameManagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class Workflow : IWorkflow
    {
        private int _currentModelNumber = 0;

        public IModel GetNextModel(IGameManager gameManager, IViewFactory viewFactory,
           ISystemResourceManager resourceManager, ModelParameters parameters)
        {
            IModel model;
            switch (_currentModelNumber)
            {
                case 0:
                    model = new PictureSelectionModel(gameManager, viewFactory, resourceManager, parameters);
                    _currentModelNumber++;
                    return model;
                case 1:
                    model = new DifficultySelectionModel(gameManager, viewFactory, resourceManager, parameters);
                    _currentModelNumber++;
                    return model;
                case 2:
                    model = new GameModel(gameManager, viewFactory, resourceManager, parameters);
                    _currentModelNumber++;
                    return model;
                default:
                    model = new PictureSelectionModel(gameManager, viewFactory, resourceManager, parameters);
                    _currentModelNumber = 0;
                    return model;
            }
        }
    }
}