using System.Collections.Generic;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Parameters
{
    public class ModelParameters
    {
        public string PictureSelectionParameter { get; private set; }
        public Sprite DifficultySelectionParameter { get; private set; }
        public Dictionary<string, GameObject> GameParameter { get; private set; }

        public ModelParameters(string pictureSelectionParameter = "", Sprite difficultySelectionParameter = null,
            Dictionary<string, GameObject> gameParameter = null)
        {
            PictureSelectionParameter = pictureSelectionParameter;
            DifficultySelectionParameter = difficultySelectionParameter;
            GameParameter = gameParameter;
        }
    }
}