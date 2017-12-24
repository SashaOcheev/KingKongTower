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
            IsStart = true;
            IsStop = false;
        }

        public void StopStage()
        {
            IsStart = false;
            IsStop = true;
        }

        public bool IsStart { get; private set; }

        public bool IsStop { get; private set; }

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
