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

        private IPhaseManager _phaseManager;

        #region IHouse members
        public Vector3 FinalPosition { get; set; }

        private Vector3 LastPosition { get; set; }

        public bool IsEnd
        {
            get
            {
                return Height >= MAX_HEIGHT;
            }
        }

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
            LastPosition = _block.transform.position;

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
            LastPosition = new Vector3(LastPosition.x, LastPosition.y + ShiftHeight, LastPosition.z);
            FinalPosition = new Vector3(LastPosition.x, LastPosition.y + ShiftHeight, LastPosition.z);

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
                return new Vector3(LastPosition.x, LastPosition.y + HEIGHT_ABOVE_HIGHEST_SETTED, LastPosition.z);
            }
        }

        private void InitPhaseManager()
        {
            _phaseManager = _block.GetComponent<PhaseManager>();
            _phaseManager.FinalBringPosition = LastPosition.x;
            _phaseManager.FinalPutPosition = LastPosition.y;
        }
    }

}