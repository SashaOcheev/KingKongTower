using UnityEngine;
using System;

namespace Scripts.Building.Pickers
{
    public class PickerModel : MonoBehaviour, IPickerModel
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
        * от -100 до 100
        */
        public float Position
        {
            get
            {
                return _position;
            }
            private set
            {
                _position = value;
            }
        }

        public void IncrementSpeed()
        {            
            _speed += SPEED_INCREMENT_VALUE ;
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

        private void Start()
        {
            _speed = START_SPEED;
        }

        private void Update()
        {
            if (Math.Abs(Position) > MAX_DEVIATION)
            {
                _speed = -_speed;
            }

            Position += _speed * Time.deltaTime;
        }

        #endregion

    }
}
