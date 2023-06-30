using System;
using UnityEngine;

namespace Assets.Puzzle.Scripts.Interfaces.UI
{
    public interface IScrollViewItem 
    {
        public event Action<Sprite> PictureClicked;
        public void ChangeImage(Sprite newImage);
    }
}