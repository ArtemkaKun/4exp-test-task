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

        /// <summary>
        /// Initialize player's data and UI connections.
        /// </summary>
        public void Initialize(Action playerLostAllHpDelegate, Action onPlayerHitDelegate)
        {
            hpManager.Initialize(playerLostAllHpDelegate, onPlayerHitDelegate);
        }

        /// <summary>
        /// Resets player data.
        /// </summary>
        public void ResetData()
        {
            hpManager.Reset();
        }
        
        /// <summary>
        /// Decrement HP's count on 1.
        /// </summary>
        public void DecrementHp()
        {
            hpManager.DecrementHp();
        }
    }
}