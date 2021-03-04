using System;
using ArtemkaKun.Scripts.PlayerSystems.WeaponSystem;
using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems
{
    /// <summary>
    /// Class, that stores and manages player's data.
    /// </summary>
    public sealed class Player : MonoBehaviour
    {
        public Vector2Int HpBounds => hpManager.HpBounds;

        [SerializeField] private HpManager hpManager;
        [SerializeField] private Weapon weapon;

        private readonly EnemyKillsManager _enemyKillsManager = new EnemyKillsManager();

        /// <summary>
        /// Initialize player's data and UI connections.
        /// </summary>
        public void Initialize(Action playerLostAllHpDelegate, Action<int> onPlayerHpChanged, Action<int> onEnemyKilledCountChanged)
        {
            hpManager.Initialize(playerLostAllHpDelegate, onPlayerHpChanged);
            
            _enemyKillsManager.Initialize(onEnemyKilledCountChanged);

            weapon.OnEnemyWasKilled += IncrementEnemyKillsCount;
        }

        private void IncrementEnemyKillsCount()
        {
            _enemyKillsManager.IncrementKilledEnemiesCount();
        }

        /// <summary>
        /// Resets player data.
        /// </summary>
        public void ResetData()
        {
            hpManager.Reset();
            
            _enemyKillsManager.Reset();
        }

        private void OnTriggerEnter(Collider enemy)
        {
            DecrementHp();
            
            Destroy(enemy.gameObject);
        }
        
        private void DecrementHp()
        {
            hpManager.DecrementHp();
        }
    }
}