using System;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.Input
{
    public interface IInputProvider
    {
        public event Action PuzzlePieceToggled;

        public void PuzzlePieceInvoked(Vector3 mousePosition);
    }
}
