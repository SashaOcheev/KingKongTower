using UnityEngine;
using System;

namespace Scripts.Building.Pickers
{
    public class PickerModel : MonoBehaviour, IPickerModel
    {
        public static float GRADATION = 200f;

        private static float MAX_DEVIATION = 100f;

        [SerializeField]
        private float ABS_MAX_ALLOWABLE_DEVIATION;

        [SerializeField]
        private float START_SPEED;

        [SerializeField]
        private float SPEED_INCREMENT_VALUE;

        private float _speed;

        private float _position = 0f;

        #region IPickerState members
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
            var sign = Math.Sign(_speed);
            var absSpeed = Math.Abs(_speed) + SPEED_INCREMENT_VALUE;
            _speed = sign * absSpeed;
        }

        public bool InBoundary
        {
            get
            {
                return Math.Abs(Position) <= ABS_MAX_ALLOWABLE_DEVIATION;
            }
        }

        public bool IsAllowable { set; get; }

        public void ChangeDirectionToTarget()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MonoBehaviour members
        private void Start()
        {
            _speed = START_SPEED;
            IsAllowable = true;
        }

        private void Update()
        {
            if (Position >= MAX_DEVIATION)
            {
                _speed = -(Math.Abs(_speed));
            }
            else if (Position <= -MAX_DEVIATION)
            {
                _speed = Math.Abs(_speed);
            }

            Position += _speed * Time.deltaTime;
        }
        #endregion
    }
}
