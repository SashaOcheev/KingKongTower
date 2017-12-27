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
        float SPEED;

        [SerializeField]
        float DEGREES_MOVE;

        IActivator _activator;

        #region Public
        public bool IsEnd { get; set; }

        #endregion

        #region IActivated
        public void Activate(Metadata metadata)
        {
            float xLen = transform.position.x - metadata.HouseCenter.x;
            float zLen = transform.position.z - metadata.HouseCenter.y;
            Radius = (float)Math.Sqrt(Math.Pow(xLen, 2d) + Math.Pow(zLen, 2d));
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

        void Start()
        {
            enabled = false;
            _activator = GetComponent<Activator>();
        }

        void Move()
        {
            
        }
    }
}