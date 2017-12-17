using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Building
{
    public class Score : MonoBehaviour, IScore
    {
        private int _height;
        private string _textFormat = "Heigth: {0}";

        private Text _textComponent;

        #region IScore members

        public int Height
        {
            set
            {
                _height = value;
                SetText();
            }
            get
            {
                return _height;
            }
        }

        #endregion

        #region MonoBehaviour members

        void Start()
        {
            _textComponent = GetComponent<Text>();
            SetText();
        }

        #endregion

        private void SetText()
        {
            _textComponent.text = string.Format(_textFormat, _height);
        }
    }
}