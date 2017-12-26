using UnityEngine;
using System.Collections;
using Scripts.Building.Pickers;
using System;

namespace Scripts.Building.SetUpBlockPhases
{
    public class BringPhase : MonoBehaviour, IPhase, IPickerObserver
    {
        IPickerSubject _pickerSubject;
        BlockPickerPosition _blockPickerPosition;

        public float FinalPosition { get; set; }

        #region IPhase members

        public bool IsEnd { get; private set; }

        void IPhase.Start()
        {
            IsEnd = false;

            _blockPickerPosition = FindObjectOfType<BlockPickerPosition>();

            _pickerSubject = FindObjectOfType<PickerSubject>();
            Register();
        }
        #endregion

        #region IPickerObserver members
        public void Register()
        {
            _pickerSubject.AddListener(this);
        }

        public void SetPosition(float position)
        {
            float beforePosition = transform.position.x;

            float afterPosition = _blockPickerPosition.Calculate(position);

            if (FinalPosition <= afterPosition && FinalPosition >= beforePosition
                || FinalPosition <= beforePosition && FinalPosition >= afterPosition)
            {
                afterPosition = FinalPosition;
                Unregister();
                IsEnd = true;
            }

            transform.position = new Vector3(afterPosition, transform.position.y, transform.position.z);         
        }

        public void Stop()
        {
            
        }

        public void Unregister()
        {
            _pickerSubject.RemoveListener(this);
        }
        #endregion

        #region MonoBehaviour members
        private void Start()
        {
            IsEnd = true;
        }
        #endregion
    }
}
