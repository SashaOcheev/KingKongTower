using UnityEngine;
using System;

namespace Scripts.Building
{
    public class PickerState : MonoBehaviour, IPickerState
    {
        [SerializeField]
        private float ABS_MAX_ALLOWABLE_DEVIATION;

        [SerializeField]
        private float MAX_DEVIATION;

        [SerializeField]
        private float START_SPEED;

        [SerializeField]
        private float SPEED_INCREMENT_VALUE;

        private float _speed;

        private float _poisition = 0f;

        #region IPickerState members

        public float AbsMaxAllowableDeviation
        {
            get
            {
                return ABS_MAX_ALLOWABLE_DEVIATION;
            }
        }

        /* Отрицательое число - мы слева от центра,
        * Положительное - справа
        */
        public float PositionPercent
        {
            get
            {
                return _poisition / MAX_DEVIATION;
            }
        }

        public void IncrementSpeed()
        {
            _speed += SPEED_INCREMENT_VALUE;
        }

        public bool InBoundary
        {
            get
            {
                return Math.Abs(_poisition) < MAX_DEVIATION;
            }
        }

        #endregion

    }
}
