using UnityEngine;
using System;

namespace Scripts.Building
{
    public class PickerState : MonoBehaviour, IPickerState
    {
        private float MAX_DEVIATION = 100f;

        [SerializeField]
        private float ABS_MAX_ALLOWABLE_DEVIATION;

        [SerializeField]
        private float START_SPEED;

        [SerializeField]
        private float SPEED_INCREMENT_VALUE;

        private float _speed;

        private float _position = 0f;

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
        public float Position
        {
            get
            {
                return _position / MAX_DEVIATION;
            }
            private set
            {
                _position = value;
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
                return Math.Abs(Position) < MAX_DEVIATION;
            }
        }

        #endregion

        #region MonoBehaviour members

        private void Update()
        {
            Position += _speed * Time.deltaTime;

            if (Math.Abs(Position) > MAX_DEVIATION)
            {
                var sign = Math.Sign(Position);
                Position = sign * Math.Abs(Position);
            }
        }

        #endregion

    }
}
