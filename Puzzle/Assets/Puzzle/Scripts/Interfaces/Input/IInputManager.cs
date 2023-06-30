namespace Assets.Puzzle.Scripts.Interfaces.Input
{
    public interface IInputManager
    {
        public void Subscribe(IInputProvider provider);
        public void Unsubscribe(IInputProvider provider);
    }
}
