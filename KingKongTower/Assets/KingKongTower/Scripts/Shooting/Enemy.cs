using UnityEngine;
using System.Collections;
using System;

namespace Scripts.Shooting
{
    public class Enemy : MonoBehaviour, IActivated
    {
        MeshRenderer _meshRenderer;
        IActivator _activator;

        #region IActivated
        public void Activate(Metadata metadata)
        {
            _meshRenderer.enabled = true;
        }

        public void Register(IActivator activator)
        {
            _activator.AddLitener(this);
        }

        public void Stop()
        {
            
        }
        #endregion

        // Use this for initialization
        void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();

            _activator = GetComponent<Activator>();
            Register(_activator);

            _meshRenderer.enabled = false;
        }
    }
}