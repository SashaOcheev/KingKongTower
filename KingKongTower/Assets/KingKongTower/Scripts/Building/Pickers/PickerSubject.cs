using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Scripts.Building.Pickers
{
    public class PickerSubject : MonoBehaviour, IPickerSubject
    {
        private List<IPickerObserver> _observers;

        #region MonoBehaviour members

        // Use this for initialization
        void Start()
        {
            _observers = new List<IPickerObserver>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        #endregion

        #region IPickerSubject members

        public void AddListener(IPickerObserver observer)
        {
            bool alreadyExist = _observers.Any(o => o == observer);
            if (alreadyExist)
            {
                throw new Exception("This observer already registered");
            }

            _observers.Add(observer);
        }

        public void SetPositionToListeners(float position)
        {
            _observers.ForEach(o => o.SetPosition(position));
        }

        public void RemoveListener(IPickerObserver observer)
        {
            bool success = _observers.Remove(observer);
            if (!success)
            {
                throw new Exception("Can not remove observer");
            }
        }

        public void Stop()
        {
            _observers.ForEach(o => o.Stop());
            enabled = false;
        }

        #endregion
    }
}