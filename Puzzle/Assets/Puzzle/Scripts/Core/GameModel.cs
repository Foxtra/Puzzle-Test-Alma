using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Core
{
    public class GameModel : IModel
    {
        private IGamePresenter _gamePresenter;
        private IGameOverPresenter _gameOverPresenter;
        private IGameManager _gameManager;
        private ISystemResourceManager _resourceManager;

        private Dictionary<int, GameObject> PictureState = new Dictionary<int, GameObject>();
        private DateTime _startTime = DateTime.Now;

        public GameModel(IGameManager gameManager, IViewFactory viewFactory,
           ISystemResourceManager resourceManager, ModelParameters parameters)
        {
            _gameManager = gameManager;
            _resourceManager = resourceManager;
            _gamePresenter = viewFactory.CreateView<IGamePresenter, Eviews>(Eviews.Game);
            _gameOverPresenter = viewFactory.CreateView<IGameOverPresenter, Eviews>(Eviews.GameOver);
            _gameOverPresenter.Disable();
            _gameOverPresenter.RestartInvoked += Restart;
            _gameOverPresenter.ExitInvoked += Exit;

            ParseChildObjects(parameters.GameParameter);
            _gamePresenter.ShowAvailablePieces(PictureState);
            _gamePresenter.ShowPlaceHolders(PictureState.Count);
            _gamePresenter.PieceMoved += CheckWinCondition;
        }

        private void ParseChildObjects(Dictionary<string, GameObject> gameParameter)
        {
            Transform[] pieces = new Transform[0];
            int count = 0;
            foreach (var item in gameParameter)
            {
                count = Constants.DifficultyDictionary[item.Key] * Constants.DifficultyDictionary[item.Key];
                _gamePresenter.SetRowsCount(Constants.DifficultyDictionary[item.Key]);
                pieces = item.Value.GetComponentsInChildren<Transform>();
                break;
            }

            for (int i = 0; i < count; i++)
            {
                //avoid 0 element which is parent
                PictureState.Add(i, pieces[i+1].gameObject);
            }
        }

        private void CheckWinCondition(List<int> arg1, List<int> arg2)
        {
            for (int i = 0; i < arg1.Count; i++)
            {
                if(arg1[i] != arg2[i])
                {
                    return;
                }
            }

            _gameOverPresenter.Enable();
            _gameOverPresenter.SetResult((DateTime.Now - _startTime).Seconds);
        }

        private void Exit()
        {
            _gameManager.ExitGame();
        }

        private void Restart()
        {
            _gameManager.RestartGame();
        }

        public void Dispose()
        {
            _gamePresenter.PieceMoved -= CheckWinCondition;
            _gamePresenter.Disable();
        }
    }
}