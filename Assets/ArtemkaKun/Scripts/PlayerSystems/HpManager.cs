using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems
{
    /// <summary>
    /// Class, that stores and manages player's hp.
    /// </summary>
    [Serializable]
    public sealed class HpManager
    {
        public Vector2Int HpBounds => hpBounds;

        [SerializeField] private Vector2Int hpBounds;

        private Action _onPlayerLostAllHp;
        private Action<int> _onPlayerHit;
        private int _currentHp;

        /// <summary>
        /// Initialize default hp and Ui.
        /// </summary>
        public void Initialize(Action playerLostAllHpDelegate, Action<int> onPlayerHitDelegate)
        {
            _onPlayerLostAllHp = playerLostAllHpDelegate;

            _onPlayerHit = onPlayerHitDelegate;

            SetHpEqualMaxBoundsValue();
        }

        /// <summary>
        /// Reset hp value (set on equal bounds max value).
        /// </summary>
        public void Reset()
        {
            SetHpEqualMaxBoundsValue();
        }

        private void SetHpEqualMaxBoundsValue()
        {
            _currentHp = hpBounds.y;

            _onPlayerHit?.Invoke(_currentHp);
        }

        /// <summary>
        /// Decrement HP's count on 1.
        /// </summary>
        public void DecrementHp()
        {
            _currentHp -= 1;

            _onPlayerHit?.Invoke(_currentHp);

            if (_currentHp == hpBounds.x)
            {
                _onPlayerLostAllHp?.Invoke();
            }
        }
    }
}