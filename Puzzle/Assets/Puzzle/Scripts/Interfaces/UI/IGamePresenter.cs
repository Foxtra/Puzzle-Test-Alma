using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IGamePresenter : IView
    {
        public event Action<List<int>, List<int>> PieceMoved;

        public void ShowAvailablePieces(List<GameObject> pictureState);
        public void ShowPlaceHolders(int placeholdersCount);
        public void SetRowsCount(int rows);
    }
}