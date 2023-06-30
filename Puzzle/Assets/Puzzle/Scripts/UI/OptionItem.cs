using Assets.Puzzle.Scripts.Interfaces.UI;
using Assets.Puzzle.Scripts.Parameters;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Puzzle.Scripts.UI
{
    public class OptionItem : MonoBehaviour, IOptionItem
    {
        public event Action<ModelParameters> OptionClicked;

        [SerializeField] private Button button;
        [SerializeField] private TMP_Text text;
        [SerializeField] Transform piecesTransform;

        private void Start()
        {
            button.onClick.AddListener(ButtonPressed);
        }

        public void SetText(string newText)
        {
            text.text = newText;
        }

        public Transform PiecesTransform => piecesTransform;

        private void ButtonPressed()
        {
            OptionClicked?.Invoke(new ModelParameters(gameParameter:
                new Dictionary<string, GameObject> { { text.text.ToString(), piecesTransform.gameObject } }));
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(ButtonPressed);
        }
    }
}