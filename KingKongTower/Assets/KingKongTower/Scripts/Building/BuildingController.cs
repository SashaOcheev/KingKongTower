using UnityEngine;

namespace Scripts.Building
{
    public class BuildingController : MonoBehaviour
    {
        IHouse _house;
        IScore _score;
        IPickerState _pickerState;

        #region MonoBehaviour members

        private void Start()
        {
            _house = GetComponent<House>();
            _house.CreateNextBlock();

            _score = FindObjectOfType<Score>();

            _pickerState = GetComponent<PickerState>();
        }

        private void Update()
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (_pickerState.InBoundary)
                    {
                        _house.CreateNextBlock();
                        _score.Height = _house.Height;

                        _pickerState.IncrementSpeed();
                    }
                }
            }
        }

        #endregion
    }
}
