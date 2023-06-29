using Cysharp.Threading.Tasks;


namespace Assets.Puzzle.Scripts.Interfaces.GameMagagement
{
    public interface IGameManager
    {
        public void ExitGame();
        public UniTask RestartLevel();
        public UniTask StartGame();
    }
}