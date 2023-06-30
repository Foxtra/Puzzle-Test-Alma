using Assets.Puzzle.Scripts.Enums;
using Assets.Puzzle.Scripts.Extensions;
using Assets.Puzzle.Scripts.Interfaces.Input;
using Assets.Puzzle.Scripts.Parameters;
using System;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Input
{
    public class PlayerInputProvider : IInputProvider
    {
        public event Action PuzzlePieceToggled;

        private readonly Camera _mainCamera;
        private RaycastHit _previousHit;
        private RaycastHit _hit;
        private Ray _ray;
        private LayerMask _layerMask = LayerMask.GetMask(ELayers.Piece.ToStringCached());

        private float _rayCastLength = Constants.Camera.RayCastLength;

        public PlayerInputProvider(Camera mainCamera) => _mainCamera = mainCamera;

        public void PuzzlePieceInvoked(Vector3 mousePosition) 
        {
            _ray = _mainCamera.ScreenPointToRay(mousePosition);

            if (!Physics.Raycast(_ray, out _hit, _rayCastLength, _layerMask)) return;
            if (_previousHit.Equals(_hit)) return;

            _previousHit = _hit;
            PuzzlePieceToggled?.Invoke();
        }
    }
}
