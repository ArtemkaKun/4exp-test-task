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
        
        [SerializeField] private IntCounter killsCounter;
        [SerializeField] private Clock roundClock;

        private void Awake()
        {
            SubscribeOnUiEvents();
        }

        private void SubscribeOnUiEvents()
        {
            OnEnemyKilled += AddOneKill;

            OnSecondPassed += AddOneSecondToRoundClock;
        }

        private void AddOneKill()
        {
            killsCounter.IncrementCounter();
        }

        private void AddOneSecondToRoundClock()
        {
            roundClock.IncrementCounter();
        }

        //DEBUG ONLY
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnSecondPassed?.Invoke();
            }
        }
#endif
    }
}
