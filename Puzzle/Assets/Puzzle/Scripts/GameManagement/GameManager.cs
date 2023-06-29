using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public static GameManager Instance { get; private set; }

        private IResourceManager _resourceManager;
        private ISystemResourceManager _systemResourceManager;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Initialize();

            DontDestroyOnLoad(gameObject);
        }

        private void Initialize()
        {
            _resourceManager = new ResourceManager();
            _systemResourceManager = new ResourceManager();
        }

        public void ExitGame()
        {
            throw new System.NotImplementedException();
        }

        public UniTask RestartLevel()
        {
            throw new System.NotImplementedException();
        }

        public UniTask StartGame()
        {
            throw new System.NotImplementedException();
        }
    }
}
