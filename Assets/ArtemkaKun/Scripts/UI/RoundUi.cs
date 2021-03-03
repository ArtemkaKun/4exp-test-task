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
        
        [SerializeField] private IntCounter killsCounter;

        private void Awake()
        {
            SubscribeOnUiEvents();
        }

        private void SubscribeOnUiEvents()
        {
            OnEnemyKilled += AddOneKill;
        }

        private void AddOneKill()
        {
            killsCounter.IncrementCounter();
        }

        //DEBUG ONLY
#if UNITY_EDITOR
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                OnEnemyKilled?.Invoke();
            }
        }
#endif
    }
}
