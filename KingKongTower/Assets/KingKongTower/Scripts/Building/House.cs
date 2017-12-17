using UnityEngine;
using System.Collections;
using System;

namespace Scripts.Building
{

    public class House : MonoBehaviour, IHouse
    {
        [SerializeField]
        private int MAX_HEIGHT;

        private int _height;

        [SerializeField]
        private GameObject _block;

        #region IBlockFactory members

        public void CreateNextBlock()
        {
            if (!CanCreateNextBlock)
            {
                throw new Exception( "You can not build House higher than MAX_HEIGHT" );
            }

            var position = new Vector3(_block.transform.position.x, _block.transform.position.y + HeightShift, _block.transform.position.z);
            _block = Instantiate(_block, position, Quaternion.identity);
            _block.name = DateTime.UtcNow.ToString();

            Height++;
        }
        
        public bool CanCreateNextBlock
        {
            get
            {
                return _height < MAX_HEIGHT;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        #endregion

        #region Monobehaviour members

        private void Start()
        {
            Height = 0;
        }

        #endregion

        private float HeightShift
        {
            get
            {
                var height = _block.GetComponent<BoxCollider>().size.y;
                var scale = _block.GetComponent<Transform>().localScale.y;
                float shift = height * scale;

                return shift;
            }
        }
    }

}