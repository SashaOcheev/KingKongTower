﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Shooting
{
    public class Activator : MonoBehaviour, IActivator
    {
        Metadata _metadata;

        List<IActivated> _listeners = new List<IActivated>();

        public void AddLitener(IActivated activated)
        {
            if (_listeners.Any(l => ReferenceEquals(activated, l)))
            {
                throw new System.Exception("Activated already exist");
            }

            _listeners.Add(activated);
        }

        public void ActivateListeners()
        {
            _listeners.ForEach(l => l.Activate(_metadata));
        }

        public void Stop()
        {
            _listeners.ForEach(l => l.Stop());
        }

        public bool IsEnd { get; set; }

        public bool IsWin { get; set; }

        public void MakeDamage()
        {
            _listeners.ForEach(l => l.MakeDamage());
        }

        private void Start()
        {
            IsWin = false;
            _metadata = FindObjectOfType<Metadata>();
        }
    }
}