using UnityEngine;
using UnityEditor;

namespace Scripts.Shooting
{
    public class GameStatus : MonoBehaviour
    {
        SpriteRenderer _sprite;
        IActivator _activator;

        [SerializeField]
        Sprite _winSprite;

        [SerializeField]
        Sprite _loseSprite;

        // Use this for initialization
        void Start()
        {
            _sprite = GetComponent<SpriteRenderer>();

            _sprite.enabled = false;
        }

        public void SetActive(bool isWin)
        {
            _sprite.sprite = isWin ? _winSprite : _loseSprite;

            _sprite.enabled = true;
        }
    }
}