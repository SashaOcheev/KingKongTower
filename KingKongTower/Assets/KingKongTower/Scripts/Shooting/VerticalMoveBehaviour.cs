using UnityEngine;
using System.Collections;
using Scripts.Building;

namespace Scripts.Shooting
{
    public class VerticalMoveBehaviour : MonoBehaviour, IActivated
    {
        float MaxHeight { get; set; }

        [SerializeField]
        float SPEED;

        IActivator _activator;

        bool IsActive { get; set; }

        #region Public
        public bool IsEnd
        {
            get
            {
                return CurrentHeight >= MaxHeight;
            }
        }
        #endregion

        #region IActivated
        public void Activate(Metadata metadata)
        {
            MaxHeight = metadata.HouseHeight;
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
        #endregion

        void Start()
        {
            _activator = GetComponent<Activator>();
            Register(_activator);

            IsActive = false;
        }

        void Update()
        {
            if (!IsActive)
            {
                return;
            }

            if (IsEnd)
            {
                _activator.IsEnd = true;
                return;
            }

            MoveUp();
        }

        void MoveUp()
        {
            transform.Translate(new Vector3(0f, SPEED, 0f));
        }

        float CurrentHeight
        {
            get
            {
                return transform.position.y;
            }
        }
    }
}