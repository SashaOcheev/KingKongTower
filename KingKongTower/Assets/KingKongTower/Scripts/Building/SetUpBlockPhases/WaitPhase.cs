using UnityEngine;
using System.Collections;

namespace Scripts.Building.SetUpBlockPhases
{
    public class WaitPhase : MonoBehaviour, IPhase
    {
        [SerializeField]
        float WAIT_TIME;

        private float _currentTime;

        #region IPhase members
        void IPhase.Start()
        {
            IsEnd = false;
            _currentTime = 0f;
        }

        public bool IsEnd { get; private set; }
        #endregion

        #region MonoBehaviour members

        private void Start()
        {
            IsEnd = true;
        }

        void Update()
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= WAIT_TIME)
            {
                IsEnd = true;
            }
        }
        #endregion
    }
}