using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class DifficultySelectionPresenter : View, IDifficultySelectionPresenter
    {
        public event Action<ModelParameters> DifficultySelected;

        [SerializeField] private Transform Content;
        [SerializeField] private OptionItem Option;
        [SerializeField] private GameObject PiecePrefab;

        private Sprite _targetSprite;
        private Dictionary<string, int> _difficultyPairs;
        private List<IOptionItem> _options = new List<IOptionItem>();

        public void SetDifficultyOptions(Sprite targetSprite, Dictionary<string, int> difficultyPairs)
        {
            _targetSprite = targetSprite;
            _difficultyPairs = difficultyPairs;
        }

        public void ShowDifficultyVariants()
        {
            foreach (var pair in _difficultyPairs)
            {
                var option = Instantiate(Option, Content);
                option.SetText(pair.Key);
                _options.Add(option);
                CreateGamePieces(PiecePrefab, option.PiecesTransform, pair.Value);
            }

            SubscribeOnButtons();
        }

        private void SubscribeOnButtons()
        {
            foreach (var option in _options)
            {
                option.OptionClicked += SelectDifficulty;
            }
        }

        private void SelectDifficulty(ModelParameters parameters)
        {
            DifficultySelected?.Invoke(parameters);
        }

        private void CreateGamePieces(GameObject piecePrefab, Transform parent, int size)
        {
            float width = _targetSprite.texture.width / (float)size;
            float height = _targetSprite.texture.height / (float)size;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    var rect = new Rect(_targetSprite.texture.width * (col / (float)size), 
                        _targetSprite.texture.height * (row / (float)size),
                        width,
                        height);

                    var sprite = Sprite.Create(_targetSprite.texture, rect, Vector2.one * 0.5f);
                    var item = Instantiate(piecePrefab, parent);
                    var areaWidth = Option.PiecesTransform.GetComponent<RectTransform>().rect.width;
                    var areaHeight = Option.PiecesTransform.GetComponent<RectTransform>().rect.height;

                    item.GetComponent<RectTransform>().sizeDelta = new Vector2(areaWidth / (float) size ,
                        areaHeight / (float) size);

                    item.GetComponent<Image>().sprite = sprite;
                    item.transform.localPosition = 
                        new Vector3(areaWidth * (col / (float)size), areaHeight * (row / (float)size), 0);

                    item.transform.localScale = new Vector3(1 - 0.1f, 1 - 0.1f, 1 - 0.1f);

                    item.name = $"{(row * size) + col}";
                }
            }
        }

        private void OnDestroy()
        {
            foreach (var option in _options)
            {
                option.OptionClicked -= SelectDifficulty;
            }
        }
    }
}