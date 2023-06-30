using System;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IPictureSelectionPresenter : IView
    {
        public event Action ExitTriggered;
        public event Action<Sprite> PictureSelected;

        public void ShowPictures(Sprite[] picturesToShow);
    }
}