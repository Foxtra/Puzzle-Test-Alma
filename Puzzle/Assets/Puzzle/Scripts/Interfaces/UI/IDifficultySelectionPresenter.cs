using Assets.Puzzle.Scripts.Parameters;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IDifficultySelectionPresenter : IView
    {
        public event Action<ModelParameters> DifficultySelected;

        public void SetDifficultyOptions(Sprite targetSprite, Dictionary<string, int> difficultyPairs);
        public void ShowDifficultyVariants();
    }
}