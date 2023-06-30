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

        public void ShowAvailablePieces(List<GameObject> pictureState)
        {
            List<GameObject> items = CreateObjects(pictureState, AvailablePiecesAreaContent);
            MoveAndResizeObjects(items, AvailablePiecesAreaContent);

            for (int i = 0; i < items.Count; i++)
            {
                items[i].AddComponent(typeof(DragAbleItem));
                _initialItems.Add(i);
                _currentItems.Add(0);
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
            _placeholderItems = CreateObjects(placeholdersCount, Placeholder.gameObject, CollectPictureAreaContent);
            MoveAndResizeObjects(_placeholderItems, CollectPictureAreaContent);

            foreach (var item in _placeholderItems)
            {
                item.GetComponent<Placeholder>().PieceWasMoved += PieceWasMoved;
            }
        }

        private List<GameObject> CreateObjects(int count, GameObject toCreate, Transform parentTransform)
        {
            List<GameObject> items = new List<GameObject>();
            for (int i = 0; i < count; i++)
            {
                var item = Instantiate(toCreate, parentTransform);
                items.Add(item);
            }
            return items;
        }

        private List<GameObject> CreateObjects(List<GameObject> toCreate, Transform parentTransform)
        {
            List<GameObject> items = new List<GameObject>();
            for (int i = 0; i < toCreate.Count; i++)
            {
                var item = Instantiate(toCreate[i], parentTransform);
                items.Add(item);
            }
            return items;
        }

        private void MoveAndResizeObjects(List<GameObject> items, Transform parentTransform)
        {
            for (int row = 0; row < _size; row++)
            {
                for (int col = 0; col < _size; col++)
                {
                    var areaWidth = parentTransform.GetComponent<RectTransform>().rect.width;
                    var areaHeight = parentTransform.GetComponent<RectTransform>().rect.height;

                    items[col + (row * _size)].GetComponent<RectTransform>().sizeDelta = new Vector2(areaWidth / (float)_size,
                        areaHeight / (float)_size);

                    items[col + (row * _size)].transform.localPosition =
                        new Vector3(areaWidth * (col / (float)_size), areaHeight * (row / (float)_size), 0);

                    items[col + (row * _size)].name = $"{(row * _size) + col}";
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
            foreach (var item in _placeholderItems)
            {
                item.GetComponent<Placeholder>().PieceWasMoved -= PieceWasMoved;
            }
        }
    }
}