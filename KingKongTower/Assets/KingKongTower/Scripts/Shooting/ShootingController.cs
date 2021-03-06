﻿using UnityEngine;
using Scripts;
using UnityEngine.SceneManagement;

namespace Scripts.Shooting
{
    public class ShootingController : MonoBehaviour, IGameStage
    {
        IActivator _activator;
        Crosshair _crossHair;
        Raycast _raycast;
        GameStatus _gameStatus;

        #region IGameStage members

        public void StartStage()
        {
            IsStart = true;
            IsStop = false;

            _activator.ActivateListeners();
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
            StopStage();
            _activator = FindObjectOfType<Activator>();
            var metadata = FindObjectOfType<Metadata>();

            _crossHair = FindObjectOfType<Crosshair>();
            _raycast = FindObjectOfType<Raycast>();
            _gameStatus = FindObjectOfType<GameStatus>();
        }

        void Update()
        {
            if (IsStop)
            {
                return;
            }

            if (_activator.IsEnd)
            {
                _gameStatus.SetActive(_activator.IsWin);
                Reload();
            }

            _crossHair.SetIsActive(false);

            MouseController();
        }

        #endregion

        void Reload()
        {
            if (Input.GetMouseButton(0))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }

        void Shoot()
        {
            _crossHair.SetIsActive(true);
            if (_raycast.IsHit)
            {
                _activator.MakeDamage();
            }
        }

        void MouseController()
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
            }
        }
    }
}
