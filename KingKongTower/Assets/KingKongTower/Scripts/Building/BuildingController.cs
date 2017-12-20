using UnityEngine;
using Scripts;
using Scripts.Building.Pickers;

namespace Scripts.Building
{
    public class BuildingController : MonoBehaviour, IGameStage
    {
        IHouse _house;
        IScore _score;
        IPickerModel _pickerModel;
        IPickerSubject _pickerSubject;

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

            _pickerModel = GetComponent<PickerModel>();

            _pickerSubject = GetComponent<PickerSubject>();
        }

        private void Update()
        {
            if (IsStop)
            {
                _pickerSubject.Stop();
                return;
            }

            _pickerSubject.SetPositionToListeners(_pickerModel.Position);

            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (_pickerModel.InBoundary)
                    {
                        _house.CreateNextBlock();
                        _score.Height = _house.Height;

                        _pickerModel.IncrementSpeed();
                    }
                }
            }
        }

        #endregion
    }
}
