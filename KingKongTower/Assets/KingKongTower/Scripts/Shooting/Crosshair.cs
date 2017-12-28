using UnityEngine;
using System.Collections;

namespace Scripts.Shooting
{
    public class Crosshair : MonoBehaviour, IActivated
    {
        SpriteRenderer _sprite;
        IActivator _activator;

        [SerializeField]
        Sprite _activeImage;

        [SerializeField]
        Sprite _passiveImage;

        private bool IsActive { get; set; }

        #region IActivated
        public void Activate(Metadata metadata)
        {
            _sprite.enabled = true;
        }

        public void Register(IActivator activator)
        {
            _activator.AddLitener(this);
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        public void MakeDamage()
        { }
        #endregion


        // Use this for initialization
        void Start()
        {
            _activator = FindObjectOfType<Activator>();
            Register(_activator);

            _sprite = GetComponent<SpriteRenderer>();

            _sprite.enabled = false;

            IsActive = false;
        }

        public void SetIsActive(bool isActive)
        {
            if (IsActive == isActive)
            {
                return;
            }

            IsActive = isActive;

            _sprite.sprite = IsActive ? _activeImage : _passiveImage;


        }
    }
}