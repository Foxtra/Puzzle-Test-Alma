using System;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IGameOverPresenter : IView
    {
        public event Action RestartInvoked;
        public event Action ExitInvoked;

        public void SetResult(double result);
    }
}