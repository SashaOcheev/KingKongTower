using UnityEngine;
using Scripts;

namespace Scripts.Shooting
{
    public class ShootingController : MonoBehaviour, IGameStage
    {
        IActivator _activator;

        #region IGameStage members

        public void StartStage()
        {
            IsStart = true;
            IsStop = false;

            _activator.ActivateListeners();
        }

        public void StopStage()
        {
            IsStart = false;
            IsStop = true;
        }

        public bool IsStart { get; private set; }

        public bool IsStop { get; private set; }

        #endregion

        #region MonoBehaviour members

        void Start()
        {
            StopStage();
            _activator = FindObjectOfType<Activator>();
            var metadata = FindObjectOfType<Metadata>();
        }

        void Update()
        {
            if (IsStop)
            {
                return;
            }

            if (_activator.IsEnd)
            {
                StopStage();
            }

            _activator.MakeDamage();
        }

        #endregion

    }
}
