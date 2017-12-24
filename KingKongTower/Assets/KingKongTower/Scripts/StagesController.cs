using UnityEngine;
using Scripts.Building;
using Scripts.Shooting;
using System.Collections.Generic;

namespace Scripts
{
    public class StagesController : MonoBehaviour
    {
        private List<IGameStage> _stageList = new List<IGameStage>();
        private IEnumerator<IGameStage> _stageEnumerator;

        #region MonoBehaviour members

        void Start()
        {
            _stageList.Clear();

            foreach ( var stage in _stageList )
            {
                stage.StopStage();
            }

            _stageEnumerator = _stageList.GetEnumerator();
            _stageEnumerator.Reset();
            _stageEnumerator.Current.StartStage();
        }

        void Update()
        {
            if (_stageEnumerator.Current.IsStop)
            {
                if (_stageEnumerator.MoveNext())
                {
                    _stageEnumerator.Current.StartStage();
                }
            }
        }

        #endregion

        private void RegisterStage()
        {
            _stageList.Add(FindObjectOfType<BuildingController>());
            _stageList.Add(FindObjectOfType<ShootingController>());
        }
    }
}