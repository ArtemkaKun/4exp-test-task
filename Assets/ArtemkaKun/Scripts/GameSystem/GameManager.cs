using System;
using ArtemkaKun.Scripts.ClockSystem;
using ArtemkaKun.Scripts.UI;
using UnityEngine;

namespace ArtemkaKun.Scripts.GameSystem
{
    /// <summary>
    /// Class, that manages game (rounds, communication between gameplay and UI, etc.). Should be one instance on this object on the scene.
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private RoundUi roundUi;
        [SerializeField] private ClockManager roundClockManager;

        private void Awake()
        {
            InitializeSystems();
        }

        private void InitializeSystems()
        {
            roundUi.Initialize();
            
            roundClockManager.Initialize(roundUi.OnTimePassed);
        }

        private void Start()
        {
            StartNewRound();
        }

        private void StartNewRound()
        {
            roundUi.ResetAllUi();
            
            roundClockManager.ActivateClock(true);
        }

        //DEBUG ONLY
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartNewRound();
            }
        }
#endif
    }
}