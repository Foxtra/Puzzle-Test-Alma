using Assets.Puzzle.Scripts.Interfaces.UI;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class ScrollViewItem : MonoBehaviour, IScrollViewItem
    {
        public event Action<Sprite> PictureClicked;

        [SerializeField] private Image image;
        [SerializeField] private Button button;

        private void Start()
        {
            button.onClick.AddListener(ButtonClicked);
        }

        public void ChangeImage (Sprite newImage)
        {
            image.sprite = newImage;
        }

        private void ButtonClicked()
        {
            PictureClicked?.Invoke(image.sprite);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(ButtonClicked);
        }
    }
}