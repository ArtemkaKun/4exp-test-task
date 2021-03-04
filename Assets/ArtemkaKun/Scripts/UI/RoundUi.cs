using System;
using ArtemkaKun.Scripts.UI.Counters;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI
{
    /// <summary>
    /// Class, that manages round UI in the game.
    /// </summary>
    public sealed class RoundUi : MonoBehaviour
    {
        public static event Action OnEnemyKilled;
        
        public static event Action OnSecondPassed;

        public static event Action OnPlayerHit;
        
        [SerializeField] private IntCounter killsCounter;
        [SerializeField] private Clock roundClock;
        [SerializeField] private HpBar hpBar;

        private void Awake()
        {
            SubscribeOnUiEvents();
        }

        private void SubscribeOnUiEvents()
        {
            OnEnemyKilled += AddOneKill;

            OnSecondPassed += AddOneSecondToRoundClock;

            OnPlayerHit += RegisterPlayerDamage;
        }

        private void AddOneKill()
        {
            killsCounter.IncrementCounter();
        }

        private void AddOneSecondToRoundClock()
        {
            roundClock.IncrementCounter();
        }

        private void RegisterPlayerDamage()
        {
            hpBar.DecreaseHp();
        }

        //DEBUG ONLY
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnPlayerHit?.Invoke();
            }
        }
#endif
    }
}
