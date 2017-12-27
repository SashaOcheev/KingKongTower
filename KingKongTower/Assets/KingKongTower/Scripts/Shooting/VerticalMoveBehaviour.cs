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

        #region Public
        public bool IsEnd {
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

        void Update()
        {
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