using UnityEngine;
using System.Collections;
using System;

namespace Scripts.Shooting
{
    public class Enemy : MonoBehaviour, IActivated
    {
        SkinnedMeshRenderer[] _meshRenderer;
        IActivator _activator;

        #region IActivated
        public void Activate(Metadata metadata)
        {
            foreach (SkinnedMeshRenderer render in _meshRenderer)
            {
                render.enabled = true;
            }
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
        { }
        #endregion

        // Use this for initialization
        void Start()
        {
            _meshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();

            _activator = GetComponent<Activator>();
            Register(_activator);

            foreach (SkinnedMeshRenderer render in _meshRenderer)
            {
                render.enabled = false;
            }
        }
    }
}