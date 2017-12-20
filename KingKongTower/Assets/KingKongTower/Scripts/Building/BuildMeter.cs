using Scripts.Building.Pickers;
using UnityEngine;

namespace Scripts.Building
{
    public class BuildMeter : MonoBehaviour, IPickerObserver
    {
        public float maxHeight;    //the max height at which we will change direction
        public float minHeight;    //the min height at which we will change direction
        private IPickerSubject _pickSubject;

        void Start()
        {
            _pickSubject = FindObjectOfType<PickerSubject>();
            Register();
        }

        public void Register()
        {
            _pickSubject.AddListener(this);
        }

        public void SetPosition(float position)
        {
            float normalizedPositionPercentRatio = (position + 100) / 200;
            transform.position = new Vector3(minHeight + (maxHeight - minHeight) * normalizedPositionPercentRatio, transform.position.y, transform.position.z);
        }

        public void Stop()
        {
            enabled = false;
        }

        public void Unregister()
        {
            _pickSubject.RemoveListener(this);
        }
    }
}

