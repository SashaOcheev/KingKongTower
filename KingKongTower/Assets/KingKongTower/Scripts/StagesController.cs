using UnityEngine;
using Scripts.Building;
using Scripts.Shooting;
using System.Collections.Generic;

namespace Scripts
{
    public class StagesController : MonoBehaviour
    {
        private List<IGameStage> _stages = new List<IGameStage>();
        private IEnumerator<IGameStage> _enumerator;

        #region MonoBehaviour members

        void Start()
        {
            _stages.Clear();

            _stages.Clear();
            Register();

            _enumerator = _stages.GetEnumerator();
            _enumerator.MoveNext();
            _enumerator.Current.StartStage();
        }

        void Update()
        {
            if (_enumerator.Current.IsStop)
            {
                if (_enumerator.MoveNext())
                {
                    _enumerator.Current.StartStage();
                }
            }
        }

        #endregion

        private void Register()
        {
            _stages.Add(FindObjectOfType<BuildingController>());
            _stages.Add(FindObjectOfType<ShootingController>());
        }
    }
}