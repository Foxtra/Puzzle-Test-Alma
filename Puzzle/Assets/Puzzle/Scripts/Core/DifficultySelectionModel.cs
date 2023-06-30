using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using System;

namespace Assets.Puzzle.Scripts.Core
{
    public class DifficultySelectionModel : IModel
    {
        private IDifficultySelectionPresenter _difficultySelectionPresenter;
        private IGameManager _gameManager;
        private ISystemResourceManager _resourceManager;

        public DifficultySelectionModel(IGameManager gameManager, IViewFactory viewFactory,
           ISystemResourceManager resourceManager, ModelParameters parameters)
        {
            _gameManager = gameManager;
            _resourceManager = resourceManager;
            _difficultySelectionPresenter = viewFactory.CreateView<IDifficultySelectionPresenter, Eviews>(Eviews.DifficultySelection);
            _difficultySelectionPresenter.DifficultySelected += SelectDifficulty;

            _difficultySelectionPresenter.SetDifficultyOptions(parameters.DifficultySelectionParameter, Constants.DifficultyDictionary);
            _difficultySelectionPresenter.ShowDifficultyVariants();
        }

        private void SelectDifficulty(ModelParameters parameters)
        {
            _gameManager.NextScreen(parameters);
        }

        public void Dispose()
        {
            _difficultySelectionPresenter.DifficultySelected -= SelectDifficulty;
            _difficultySelectionPresenter.Disable();
        }
    }
}