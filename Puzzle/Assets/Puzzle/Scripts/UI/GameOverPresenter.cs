using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class GameOverPresenter : View, IGameOverPresenter
    {
        public event Action RestartInvoked;
        public event Action ExitInvoked;

        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text resultText;

        private void Start()
        {
            restartButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Exit);
        }

        public void SetResult(double result)
        {
            resultText.text = $"{Constants.GameOverText}:  {TimeSpan.FromSeconds(result)}";
        }

        private void Exit()
        {
            ExitInvoked?.Invoke();
        }

        private void Restart()
        {
            RestartInvoked?.Invoke();
        }

        private void OnDestroy()
        {
            restartButton.onClick.RemoveListener(Restart);
            restartButton.onClick.RemoveListener(Exit);
        }
    }
}