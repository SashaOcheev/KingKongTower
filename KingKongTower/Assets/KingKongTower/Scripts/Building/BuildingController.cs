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

        #region IGameStage members

        public void StartStage()
        {
            IsStart = true;
            IsStop = false;
        }

        public void StopStage()
        {
            IsStart = false;
            IsStop = true;
        }

        public bool IsStart { get; private set; }

        public bool IsStop { get; private set; }

        #endregion

        #region MonoBehaviour members

        private void Start()
        {
            _house = GetComponent<House>();

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

            _pickerModel.IsAllowable = _house.IsPutted;

            _pickerSubject.SetPositionToListeners(_pickerModel.Position);

            MouseControl();
        }

        #endregion

        private void MouseControl()
        {
            if (Input.GetMouseButtonDown(0))
            {
                PutBlock();
            }
        }

        private void TouchControl()
        {
            foreach (var touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    PutBlock();
                }
            }
        }

        private void PutBlock()
        {
            if (_house.IsEnd)
            {
                return;
            }

            if (_pickerModel.InBoundary)
            {
                _house.PutBlock();
                _score.Height = _house.Height;

                _pickerModel.IncrementSpeed();
            }
        }
    }
}
