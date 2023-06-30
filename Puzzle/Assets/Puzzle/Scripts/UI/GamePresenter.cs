using Assets.Puzzle.Scripts.Interfaces.UI;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class GamePresenter : View, IGamePresenter
    {
        public event Action<List<int>, List<int>> PieceMoved;

        [SerializeField] private Transform AvailablePiecesAreaContent;
        [SerializeField] private Transform CollectPictureAreaContent;
        [SerializeField] private Placeholder Placeholder;
        private System.Random _random = new System.Random();

        private List<int> _initialItems = new List<int>();
        private List<int> _currentItems = new List<int>();
        List<GameObject> _placeholderItems = new List<GameObject>();

        private int _size;

        public void SetRowsCount(int size) => _size = size;

        public void ShowAvailablePieces(Dictionary<int, GameObject> pictureState)
        {
            List<GameObject> items = new List<GameObject>();
            foreach (var item in pictureState)
            {
                var go = Instantiate(item.Value, AvailablePiecesAreaContent);
                go.AddComponent(typeof(DragAbleItem));
                items.Add(go);
            }

            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    var areaWidth = AvailablePiecesAreaContent.GetComponent<RectTransform>().rect.width;
                    var areaHeight = AvailablePiecesAreaContent.GetComponent<RectTransform>().rect.height;

                    items[col + (row * _size)].GetComponent<RectTransform>().sizeDelta = new Vector2(areaWidth / (float)_size,
                        areaHeight / (float)_size);

                    items[col + (row * _size)].transform.localPosition =
                        new Vector3(areaWidth * (col / (float)_size), areaHeight * (row / (float)_size), 0);

                    items[col + (row * _size)].name = $"{(row * _size) + col}";
                    _initialItems.Add(col + (row * _size));
                    _currentItems.Add(0);
                }
            }

            for (int i = 0; i < items.Count; i++)
            {
                var temp = items[i].transform.localPosition ;
                var j = _random.Next(items.Count - 1);
                items[i].transform.localPosition = items[j].transform.localPosition;
                items[j].transform.localPosition = temp;
            }
        }

        public void ShowPlaceHolders(int placeholdersCount)
        {
            List<GameObject> _placeholderItems = new List<GameObject>();
            for (int i = 0; i < placeholdersCount; i++)
            {
                var item = Instantiate(Placeholder, CollectPictureAreaContent);
                item.PieceWasMoved += PieceWasMoved;
                _placeholderItems.Add(item.transform.gameObject);

            }

            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    var areaWidth = CollectPictureAreaContent.GetComponent<RectTransform>().rect.width;
                    var areaHeight = CollectPictureAreaContent.GetComponent<RectTransform>().rect.height;

                    _placeholderItems[col + (row * _size)].GetComponent<RectTransform>().sizeDelta = new Vector2(areaWidth / (float)_size,
                        areaHeight / (float)_size);

                    _placeholderItems[col + (row * _size)].transform.localPosition =
                        new Vector3(areaWidth * (col / (float)_size), areaHeight * (row / (float)_size), 0);

                    _placeholderItems[col + (row * _size)].name = $"{(row * _size) + col}";
                }
            }
        }

        private void PieceWasMoved(int index, int element)
        {
            _currentItems[index] = element;
            PieceMoved?.Invoke(_initialItems, _currentItems);
        }

        private void OnDestroy()
        {
            for (int i = 0; i < _placeholderItems.Count; i++)
            {
                _placeholderItems[i].GetComponent<Placeholder>().PieceWasMoved -= PieceWasMoved;
            }
        }
    }
}