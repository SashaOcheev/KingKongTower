using UnityEngine;
using System.Collections;

namespace Scripts.Shooting
{
    public class KingKong : MonoBehaviour, IActivated
    {
        IActivator _activator;
        MeshRenderer _meshRenderer;

        #region IActivated
        public void Activate(Metadata metadata)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.enabled = true;
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

        // Use this for initialization
        void Start()
        {
            _activator = GetComponent<Activator>();
            _meshRenderer.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
