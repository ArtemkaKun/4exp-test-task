using System;
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

        private readonly EnemyKillsManager _enemyKillsManager = new EnemyKillsManager();

        /// <summary>
        /// Initialize player's data and UI connections.
        /// </summary>
        public void Initialize(Action playerLostAllHpDelegate, Action<int> onPlayerHpChanged, Action<int> onEnemyKilledCountChanged)
        {
            hpManager.Initialize(playerLostAllHpDelegate, onPlayerHpChanged);
            
            _enemyKillsManager.Initialize(onEnemyKilledCountChanged);
        }

        /// <summary>
        /// Resets player data.
        /// </summary>
        public void ResetData()
        {
            hpManager.Reset();
            
            _enemyKillsManager.Reset();
        }

        /// <summary>
        /// Decrement HP's count on 1.
        /// </summary>
        public void DecrementHp()
        {
            hpManager.DecrementHp();
        }

        /// <summary>
        /// Increments of killed enemies count by 1.
        /// </summary>
        public void IncrementEnemyKillsCount()
        {
            _enemyKillsManager.IncrementKilledEnemiesCount();
        }
    }
}