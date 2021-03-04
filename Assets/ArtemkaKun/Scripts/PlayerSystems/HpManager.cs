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
        private Action<int> _onPlayerHpChanged;
        private int _currentHp;

        /// <summary>
        /// Initialize delegates and set default hp value.
        /// </summary>
        /// <param name="playerLostAllHpDelegate">Delegate to invoke when player lost all hp.</param>
        /// <param name="onPlayerHpChanged">Delegate to invoke when player's hp was changed.</param>
        public void Initialize(Action playerLostAllHpDelegate, Action<int> onPlayerHpChanged)
        {
            _onPlayerLostAllHp = playerLostAllHpDelegate;

            _onPlayerHpChanged = onPlayerHpChanged;

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

            _onPlayerHpChanged?.Invoke(_currentHp);
        }

        /// <summary>
        /// Decrement HP's count on 1.
        /// </summary>
        public void DecrementHp()
        {
            _currentHp -= 1;

            _onPlayerHpChanged?.Invoke(_currentHp);

            if (_currentHp == hpBounds.x)
            {
                _onPlayerLostAllHp?.Invoke();
            }
        }
    }
}