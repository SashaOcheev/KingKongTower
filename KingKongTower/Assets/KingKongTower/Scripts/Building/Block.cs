using System;
using Scripts.Building.Pickers;
using UnityEngine;

namespace Scripts.Building
{
    public class Block : MonoBehaviour, IBlock
    {
        IPickerSubject _pickerSubject;
        BlockPickerPosition _blockPickerPosition;

        #region IPickerObserver members
        public void Register()
        {
            _pickerSubject.AddListener(this);
        }

        public void SetPosition(float position)
        {
            float newPosition = _blockPickerPosition.Calculate(position);
            transform.position = new Vector3(
                newPosition,
                transform.position.y,
                transform.position.z
            );
        }

        public void Stop()
        {
            enabled = false;
        }

        public void Unregister()
        {
            _pickerSubject.RemoveListener(this);
        }

        public void Put()
        {
            Unregister();
        }
        #endregion

        #region MonoBehaviour members
        private void Start()
        {
            name = string.Format("block_{0}", DateTime.UtcNow.ToString());

            _pickerSubject = FindObjectOfType<PickerSubject>();

            Register();

            _blockPickerPosition = FindObjectOfType<BlockPickerPosition>();
        }
        #endregion
    }
}