using Scripts.Building.Pickers;
using System;
using UnityEngine;

namespace Scripts.Building.SetUpBlockPhases
{
    public class PutPhase : MonoBehaviour, IPhase
    {
        [SerializeField]
        private float FALL_SPEED;

        public float FinalPosition { set; private get; }

        #region IPhase
        public bool IsEnd { get; private set; }

        void IPhase.Start()
        {
            IsEnd = false;
        }
        #endregion

        #region MonoBehaviour members
        private void Start()
        {
            IsEnd = true;
        }

        private void Update()
        {
            if (IsEnd)
            {
                return;
            }

            var position = transform.position;
            if (transform.position.y >= FinalPosition)
            {             
                transform.position = new Vector3(position.x, position.y - FALL_SPEED * Time.deltaTime, position.z);
            }
            else
            {
                transform.position = new Vector3(position.x, FinalPosition, position.z);
                IsEnd = true;
            }
        }
        #endregion
    }
}
