using UnityEngine;
using System.Collections;

namespace Scripts.Shooting
{
    public class HealthComponent : MonoBehaviour, IActivated
    {
        float START_HEALTH = 100;

        [SerializeField]
        float DECREMENT_HELATH;

        float Health { get; set; }

        bool IsActive { get; set; }

        IActivator _activator;

        #region Public
        #endregion

        #region IActivated
        public void Activate(Metadata metadata)
        {
            IsActive = true;
        }

        public void Register(IActivator activator)
        {
            _activator.AddLitener(this);
        }

        public void Stop()
        {
            enabled = false;
        }

        public void MakeDamage()
        {
            DecrementHealth();
        }
        #endregion

        // Use this for initialization
        void Start()
        {
            _activator = GetComponent<Activator>();
            Register(_activator);

            IsActive = false;

            Health = START_HEALTH;
        }

        private void DecrementHealth()
        {
            if (!IsActive)
            {
                return;
            }

            Health -= DECREMENT_HELATH;

            if (Health <= 0)
            {
                _activator.IsWin = true;
                _activator.IsEnd = true;
            }
        }
    }
}