using UnityEngine;
using Scripts;

namespace Scripts.Building
{
    public class BuildingController : MonoBehaviour, IGameStage
    {
        IHouse _house;
        IScore _score;
        IPickerState _pickerState;

        private bool _isStart;
        private bool _isStop;

        #region IGameStage members

        public void StartStage()
        {
            _isStart = true;
            _isStop = false;
        }

        public void StopStage()
        {
            _isStart = false;
            _isStop = true;
        }

        public bool IsStart
        {
            get
            {
                return _isStart;
            }
        }

        public bool IsStop
        {
            get
            {
                return _isStop;
            }
        }

        #endregion

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
            if (IsStop)
            {
                return;
            }

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
