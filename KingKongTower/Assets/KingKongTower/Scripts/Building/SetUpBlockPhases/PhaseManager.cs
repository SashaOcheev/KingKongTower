using UnityEngine;
using System.Collections.Generic;

namespace Scripts.Building.SetUpBlockPhases
{
    public class PhaseManager : MonoBehaviour, IPhaseManager
    {
        List<IPhase> _phases = new List<IPhase>();
        IEnumerator<IPhase> _enumerator;

        #region IPhaseManager members

        public float FinalBringPosition { set; private get; }

        public float FinalPutPosition { set; private get; }

        public bool IsEnd { get; private set; }

        void IPhaseManager.Start()
        {
            IsEnd = false;

            _phases.Clear();
            Register();

            _enumerator = _phases.GetEnumerator();
            _enumerator.MoveNext();
            _enumerator.Current.Start();
        }
        #endregion

        #region MonoBehaviour members

        private void Start()
        {
            IsEnd = true;
        }

        void Update()
        {
            if (IsEnd)
            {
                return;
            }

            if (!_enumerator.Current.IsEnd)
            {
                return;
            }

            bool hasNext = _enumerator.MoveNext();
            if (!hasNext)
            {
                IsEnd = true;
            }
            else
            {
                _enumerator.Current.Start();
            }
            
        }
        #endregion

        void Register()
        {
            BringPhase bringPhase = GetComponent<BringPhase>();
            bringPhase.FinalPosition = FinalBringPosition;
            _phases.Add(bringPhase);

            PutPhase putPhase = GetComponent<PutPhase>();
            putPhase.FinalPosition = FinalPutPosition;
            _phases.Add(putPhase);

            WaitPhase waitPhase = GetComponent<WaitPhase>();
            _phases.Add(waitPhase);
        }
    }
}