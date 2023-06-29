using Assets.BackToSchool.Scripts.Enums;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using UnityEngine;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class Starter : MonoBehaviour
    {
        private void Start()
        {
            ISystemResourceManager resourceManager = new ResourceManager();
            IGameManager gameManager = GameManager.Instance;
            if (gameManager == null)
                gameManager = resourceManager.CreatePrefabInstance<GameManager, EGame>(EGame.GameManager);

            StartGame(gameManager);
        }

        private async void StartGame(IGameManager manager) => await manager.StartGame();
    }
}
