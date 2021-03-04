using System;
using ArtemkaKun.Scripts.ClockSystems;
using ArtemkaKun.Scripts.PlayerSystems;
using ArtemkaKun.Scripts.UI;
using UnityEngine;

namespace ArtemkaKun.Scripts.GameSystems
{
    /// <summary>
    /// Class, that manages game (rounds, communication between gameplay and UI, etc.). Should be one instance on this object on the scene.
    /// </summary>
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private RoundUi roundUi;
        [SerializeField] private ClockManager roundClockManager;
        [SerializeField] private Player playerManager;

        private Action<TimeSpan> _onTimeChanged;
        private Action _onPlayerLostAllHp;
        private Action<int> _onPlayerHit;

        private void Awake()
        {
            InitializeGameManagerDelegates();

            InitializeSystems();
        }

        private void InitializeGameManagerDelegates()
        {
            _onTimeChanged = ReactOnTimePassedEvent;

            _onPlayerHit = ReactOnPlayerHit;

            _onPlayerLostAllHp += StopRound;
        }

        private void ReactOnTimePassedEvent(TimeSpan newTimeValue)
        {
            roundUi.ChangeRoundClockValue(newTimeValue);
        }

        private void ReactOnPlayerHit(int newValue)
        {
            roundUi.ChangePlayerHp(newValue);
        }

        private void StopRound()
        {
            StartNewRound();
            Debug.Log("Round is over");
        }

        private void InitializeSystems()
        {
            roundUi.Initialize(playerManager.HpBounds);

            roundClockManager.Initialize(_onTimeChanged);

            playerManager.Initialize(_onPlayerLostAllHp, _onPlayerHit);
        }

        private void Start()
        {
            StartNewRound();
        }

        private void StartNewRound()
        {
            roundClockManager.ResetValue();

            roundClockManager.ActivateClock(true);

            playerManager.ResetData();
        }

        //DEBUG ONLY
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartNewRound();
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                playerManager.DecrementHp();
            }
        }
#endif
    }
}