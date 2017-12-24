using UnityEngine;
using System.Collections;
using System;
using Scripts.Building.SetUpBlockPhases;

namespace Scripts.Building
{
    public class House : MonoBehaviour, IHouse
    {
        [SerializeField]
        private int MAX_HEIGHT;

        [SerializeField]
        private float HEIGHT_ABOVE_HIGHEST_SETTED;

        [SerializeField]
        private Block _block;

        private Vector3 FinalPosition { get; set; }

        private IPhaseManager _phaseManager;

        #region IHouse members
        public bool IsEnd { get; private set; }

        public bool IsPutted { get; private set; }

        public void PutBlock()
        {
            IsPutted = false;
            _phaseManager.Start();
            _block.Put();

            Height++;
        }

        public int Height { get; private set; }
        #endregion

        #region Monobehaviour members
        private void Start()
        {
            FinalPosition = _block.transform.position;

            IsEnd = false;
            IsPutted = true;

            InitPhaseManager();

            _block.transform.position = CreationPosition;
        }

        private void Update()
        {
            if (!IsPutted && _phaseManager.IsEnd)
            {
                InitBlock();
            }
        }
        #endregion

        private void InitBlock()
        {
            FinalPosition = new Vector3(FinalPosition.x, FinalPosition.y + ShiftHeight, FinalPosition.z);

            _block = Instantiate(
                _block,
                CreationPosition,
                Quaternion.identity
            );

            InitPhaseManager();

            IsPutted = true;
        }

        private float ShiftHeight
        {
            get
            {
                var size = _block.GetComponent<BoxCollider>().size.y;
                var scale = _block.transform.localScale.y;
                float shift = size * scale;

                return shift;
            }
        }

        private Vector3 CreationPosition
        {
            get
            {
                return new Vector3(FinalPosition.x, FinalPosition.y + HEIGHT_ABOVE_HIGHEST_SETTED, FinalPosition.z);
            }
        }

        private void InitPhaseManager()
        {
            _phaseManager = _block.GetComponent<PhaseManager>();
            _phaseManager.FinalBringPosition = FinalPosition.x;
            _phaseManager.FinalPutPosition = FinalPosition.y;
        }
    }

}