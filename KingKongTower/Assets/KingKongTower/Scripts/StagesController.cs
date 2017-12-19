using UnityEngine;
using Scripts.Building;
using Scripts.Shooting;
using System.Collections.Generic;

namespace Scripts
{
    public class StagesController : MonoBehaviour
    {
        List<IGameStage> _stageList;
        IEnumerator<IGameStage> _stageEnumerator;

        #region MonoBehaviour members

        // Use this for initialization
        void Start()
        {
            _stageList.Add(FindObjectOfType<BuildingController>());
            _stageList.Add(FindObjectOfType<ShootingController>());
            
            foreach ( var stage in _stageList )
            {
                stage.StopStage();
            }

            _stageEnumerator = _stageList.GetEnumerator();
            _stageEnumerator.Reset();
            _stageEnumerator.Current.StartStage();
        }

        // Update is called once per frame
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
    }
}