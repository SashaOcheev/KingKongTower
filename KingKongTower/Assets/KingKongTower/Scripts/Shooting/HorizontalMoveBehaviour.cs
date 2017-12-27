using UnityEngine;
using System.Collections;
using Scripts.Building;
using System;

namespace Scripts.Shooting
{
    public class HorizontalMoveBehaviour : MonoBehaviour, IActivated
    {
        float Radius { get; set; }

        [SerializeField]
        float ANGLE_SPEED;

        [SerializeField]
        float DEGREES_SHIFT;

        Vector3 Origin { get; set; }

        float ShiftReminder { get; set; }

        bool IsActive { get; set; }

        int Direction { get; set; }

        IActivator _activator;

        #region Public
        public void MakeDamage()
        {
            if (Direction != 0)
            {
                return;
            }

            float directionSeed = UnityEngine.Random.Range(-1f, 1f);
            if (directionSeed == 0f)
            {
                directionSeed += 1;
            }
            Direction = Math.Sign(directionSeed);

            ShiftReminder = ANGLE_SPEED * Direction;
        }

        #endregion

        #region IActivated
        public void Activate(Metadata metadata)
        {
            IsActive = true;

            float xLen = transform.position.x - metadata.HouseCenter.x;
            float zLen = transform.position.z - metadata.HouseCenter.y;
            Radius = (float)Math.Sqrt(Math.Pow(xLen, 2d) + Math.Pow(zLen, 2d));

            Origin = new Vector3(metadata.HouseCenter.x, 0f, metadata.HouseCenter.y);
        }

        public void Register(IActivator activator)
        {
            _activator.AddLitener(this);
        }

        public void Stop()
        {
            enabled = true;
        }
        #endregion

        private void Start()
        {
            IsActive = true;
            ShiftReminder = 0f;
            _activator = GetComponent<Activator>();
            Direction = 0;
        }

        private void Update()
        {
            if (!IsActive)
            {
                return;
            }

            Move();
        }

        void Move()
        {
            if (Direction == 0)
            {
                return;
            }

            float shift = Time.deltaTime * ANGLE_SPEED * Direction;

            transform.RotateAround(Origin, Vector3.right, shift);

            ShiftReminder -= shift;

            if (ShiftReminder <= 0)
            {
                ShiftReminder = 0f;
                Direction = 0;
            }
        }
    }
}