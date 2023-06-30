using Assets.Puzzle.Scripts.Parameters;
using Cysharp.Threading.Tasks;


namespace Assets.Puzzle.Scripts.Interfaces.GameMagagement
{
    public interface IGameManager
    {
        public void ExitGame();
        public void NextScreen(ModelParameters parameters);
        public UniTask RestartGame();
        public UniTask StartGame();
    }
}