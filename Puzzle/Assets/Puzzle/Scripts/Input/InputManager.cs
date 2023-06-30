using Assets.Puzzle.Scripts.Interfaces.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Inputs
{

    public class InputManager : MonoBehaviour, IInputManager
    {
        private Vector3 _mousePosition;

        private List<IInputProvider> _providers = new List<IInputProvider>();

        public void Subscribe(IInputProvider provider) => _providers.Add(provider);

        public void Unsubscribe(IInputProvider provider) => _providers.Remove(provider);

        private void Update()
        {
            CheckPuzzlePiece();
        }

        private void CheckPuzzlePiece()
        {
            if (!UnityEngine.Input.GetButtonDown("Fire1"))
                return;

            _mousePosition = UnityEngine.Input.mousePosition;

            foreach (var provider in _providers)
                provider.PuzzlePieceInvoked(_mousePosition);
        }
    }
}
