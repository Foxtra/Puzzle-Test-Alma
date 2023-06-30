using Assets.Puzzle.Scripts.Parameters;
using System;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IOptionItem 
    {
        public event Action<ModelParameters> OptionClicked;
        public Transform PiecesTransform { get; }
        public void SetText(string newText);
    }
}