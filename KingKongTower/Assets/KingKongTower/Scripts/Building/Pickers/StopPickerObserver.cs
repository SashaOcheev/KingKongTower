using UnityEngine;
using System.Collections;
using System;

namespace Scripts.Building.Pickers
{
    public class StopPickerObserver : MonoBehaviour, IPickerObserver
    {
        IPickerSubject _pickerSubject;

        public void Register()
        {
            _pickerSubject.AddListener(this);
        }

        public void SetPosition(float position)
        {
        }

        public void Stop()
        {
            Destroy(gameObject);
        }

        public void Unregister()
        {
        }

        private void Start()
        {
            _pickerSubject = FindObjectOfType<PickerSubject>();
            Register();
        }
    }
}
