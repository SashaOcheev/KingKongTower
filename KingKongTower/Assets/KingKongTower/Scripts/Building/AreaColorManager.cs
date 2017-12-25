using UnityEngine;
using System.Collections;
using Scripts.Building.Pickers;
using UnityEngine.UI;

namespace Scripts.Building
{
    public class AreaColorManager : MonoBehaviour
    {
        IPickerModel _pickerModel;

        Image _image;

        [SerializeField]
        Sprite _allowedSprite;

        [SerializeField]
        Sprite _unallowedSprite;

        private bool IsAllowable { get; set; }

        // Use this for initialization
        void Start()
        {
            _pickerModel = FindObjectOfType<PickerModel>();
            _image = GetComponent<Image>();
            IsAllowable = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (_pickerModel.IsAllowable != IsAllowable)
            {
                IsAllowable = _pickerModel.IsAllowable;

                _image.sprite = IsAllowable ? _allowedSprite : _unallowedSprite;
            }
        }
    }
}