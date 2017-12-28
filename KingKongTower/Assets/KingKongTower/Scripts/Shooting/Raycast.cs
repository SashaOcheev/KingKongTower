using UnityEngine;
using System.Collections;
namespace Scripts.Shooting
{
    public class Raycast : MonoBehaviour, IActivated
    {
        Camera _cam;
        Enemy _enemy;
        IActivator _activator;
        
        bool IsActive { get; set; }

        public bool IsHit { get; private set; }

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
        { }

        public void MakeDamage()
        { }
        #endregion

        void Start()
        {
            _cam = GetComponent<Camera>();
            _enemy = FindObjectOfType<Enemy>();
            IsActive = false;

            _activator = FindObjectOfType<Activator>();
            Register(_activator);

            IsHit = false;
        }

        void Update()
        {
            if (!IsActive)
            {
                IsHit = false;
                return;
            }

            Ray ray = _cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                IsHit = hit.transform.name == "Robo1";
                return;
            }

            IsHit = false;
            return;
        }
    }
}