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
        private Action<int> _onPlayerHpChanged;
        private Action<int> _onEnemyKilledCountChanged;

        private void Awake()
        {
            InitializeGameManagerDelegates();

            InitializeSystems();
        }

        private void InitializeGameManagerDelegates()
        {
            _onTimeChanged += ReactOnTimeChangedEvent;

            _onPlayerHpChanged += ReactOnPlayerHit;

            _onEnemyKilledCountChanged += ReactOnEnemyKilledCountChangedEvent;

            _onPlayerLostAllHp += StopRound;
        }

        private void ReactOnTimeChangedEvent(TimeSpan newTimeValue)
        {
            roundUi.ChangeRoundClockValue(newTimeValue);
        }

        private void ReactOnPlayerHit(int newValue)
        {
            roundUi.ChangePlayerHp(newValue);
        }

        private void ReactOnEnemyKilledCountChangedEvent(int newKillsValue)
        {
            roundUi.ChangeKilledEnemiesCount(newKillsValue);
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

            playerManager.Initialize(_onPlayerLostAllHp, _onPlayerHpChanged, _onEnemyKilledCountChanged);
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
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                playerManager.IncrementEnemyKillsCount();
            }
        }
#endif
    }
}