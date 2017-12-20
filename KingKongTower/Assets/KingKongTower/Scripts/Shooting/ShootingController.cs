using UnityEngine;
using Scripts;

namespace Scripts.Shooting
{
    public class ShootingController : MonoBehaviour, IGameStage
    {


        private bool _isStart;
        private bool _isStop;

        #region IGameStage members

        public void StartStage()
        {
            _isStart = true;
            _isStop = false;
        }

        public void StopStage()
        {
            _isStart = false;
            _isStop = true;
        }

        public bool IsStart
        {
            get
            {
                return _isStart;
            }
        }

        public bool IsStop
        {
            get
            {
                return _isStop;
            }
        }

        #endregion

        #region MonoBehaviour members

        void Start()
        {

        }

        void Update()
        {
            if (IsStop)
            {
                return;
            }
        }

        #endregion

    }
}
