using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Core
{
    public class PictureSelectionModel : IModel
    {
        private IPictureSelectionPresenter _pictureSelectionPresenter;
        private IGameManager _gameManager;
        private ISystemResourceManager _resourceManager;

        private Sprite[] _sprites;

        public PictureSelectionModel(IGameManager gameManager, IViewFactory viewFactory, 
            ISystemResourceManager resourceManager, ModelParameters parameters)
        {
            _gameManager = gameManager;
            _resourceManager = resourceManager;
            _pictureSelectionPresenter = viewFactory.CreateView<IPictureSelectionPresenter, Eviews>(Eviews.PictureSelection);
            _pictureSelectionPresenter.ExitTriggered += ExitGame;
            _pictureSelectionPresenter.PictureSelected += SelectDifficulty;

            GetPictures(parameters.PictureSelectionParameter);
            _pictureSelectionPresenter.ShowPictures(_sprites);
        }

        private void GetPictures(string picturesPath)
        {
            _sprites = _resourceManager.GetAllAssets<Sprite>(picturesPath);
        }

        private void ExitGame() => _gameManager.ExitGame();

        private void SelectDifficulty(Sprite selectedPicture) => 
            _gameManager.NextScreen(new ModelParameters(difficultySelectionParameter: selectedPicture));

        public void Dispose()
        {
            _pictureSelectionPresenter.ExitTriggered -= ExitGame;
            _pictureSelectionPresenter.PictureSelected -= SelectDifficulty;
            _pictureSelectionPresenter.Disable();
        }
    }
}