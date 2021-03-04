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
        
        public Action<float> OnTimePassed { get; private set; }

        public static event Action OnPlayerHit;
        
        [SerializeField] private IntCounter killsCounter;
        [SerializeField] private ClockUi roundClockUi;
        [SerializeField] private HpBar hpBar;
        
        /// <summary>
        /// Initialize UI subscriptions and members. Should be used instead of Awake() method.
        /// </summary>
        public void Initialize()
        {
            SubscribeOnUiEvents();
        }

        private void SubscribeOnUiEvents()
        {
            OnEnemyKilled += AddOneKill;

            OnTimePassed += AddTimeToRoundClock;

            OnPlayerHit += RegisterPlayerDamage;
        }

        private void AddOneKill()
        {
            killsCounter.IncrementCounter();
        }

        private void AddTimeToRoundClock(float passedTime)
        {
            roundClockUi.AddTimeToClock(passedTime);
        }

        private void RegisterPlayerDamage()
        {
            hpBar.DecreaseHp();
        }

        public void ResetAllUi()
        {
            killsCounter.ResetCounter();
            
            roundClockUi.ResetCounter();
            
            hpBar.ResetValue();
        }
    }
}
