using Assets.Puzzle.Scripts.Interfaces.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class PictureSelectionPresenter : View, IPictureSelectionPresenter
    {
        public event Action ExitTriggered;
        public event Action<Sprite> PictureSelected;

        [SerializeField] Transform ScrollContent;
        [SerializeField] GameObject PicturePrefab;
        [SerializeField] Button ExitButton;

        private List<IScrollViewItem> _pictures = new List<IScrollViewItem>();

        private void Start()
        {
            ExitButton.onClick.AddListener(ExitGame);
        }

        public void ShowPictures(Sprite[] picturesToShow)
        {
            foreach (var picture in picturesToShow)
            {
               GameObject obj = Instantiate(PicturePrefab, ScrollContent);
                var item = obj.GetComponent<IScrollViewItem>();
                item.ChangeImage(picture);
                item.PictureClicked += SelectPictire;
                _pictures.Add(item);
            }
        }

        private void ExitGame() => ExitTriggered?.Invoke();
        private void SelectPictire(Sprite picture) => PictureSelected?.Invoke(picture);

        private void OnDestroy()
        {
            ExitButton.onClick.RemoveListener(ExitGame);
            foreach (var picture in _pictures)
            {
                picture.PictureClicked -= SelectPictire;
            }
        }
    }
}