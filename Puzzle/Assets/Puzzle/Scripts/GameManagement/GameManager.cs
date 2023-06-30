using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Extensions;
using Assets.Puzzle.Scripts.Interfaces.Core;
using Assets.Puzzle.Scripts.Interfaces.GameMagagement;
using Assets.Puzzle.Scripts.Interfaces.GameManagement;
using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using Assets.Puzzle.Scripts.UI;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Puzzle.Scripts.GameManagement
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        public static GameManager Instance { get; private set; }

        private IResourceManager _resourceManager;
        private ISystemResourceManager _systemResourceManager;
        private IViewFactory _viewFactory;
        private IModel _currentModel;
        private IWorkflow _workflow;
        private Camera _mainCamera;

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
            _workflow = new Workflow();
        }

        public  void ExitGame() => Application.Quit();

        public async UniTask RestartGame()
        {
            await StartGame();
        }

        public async UniTask StartGame()
        {
            await SceneManager.LoadSceneAsync(EScenes.Game.ToStringCached());
            InitializeScene();
            _currentModel = _workflow.GetNextModel(this, _viewFactory, _systemResourceManager,
                new ModelParameters(Constants.PicturesPath));
        }

        private void InitializeScene()
        {
            _mainCamera = _resourceManager.CreateCamera();
            var uiRoot = _resourceManager.CreateUIRoot(_mainCamera);
            _viewFactory = new ViewFactory(_systemResourceManager, uiRoot);
        }

        public void NextScreen(ModelParameters parameters)
        {
            _currentModel?.Dispose();
            _currentModel = _workflow.GetNextModel(this, _viewFactory, _systemResourceManager, parameters);
        }
    }
}
