using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems.PlayerManagement
{
    /// <summary>
    ///     Class, that stores and manages player's hp.
    /// </summary>
    [Serializable]
    public sealed class HpManager
    {
        [SerializeField] private Vector2Int hpBounds;

        private int _currentHp;
        
        private Action<int> _onPlayerHpChanged;
        private Action _onPlayerLostAllHp;

        public Vector2Int HpBounds => hpBounds;

        /// <summary>
        ///     Initialize delegates and set default hp value.
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
        ///     Reset hp value (set on equal bounds max value).
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
        ///     Decrement HP's count on 1.
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

        /// <summary>
        ///     Increment HP's count on 1.
        /// </summary>
        public void IncrementHp()
        {
            if (_currentHp == hpBounds.y)
            {
                return;
            }

            _currentHp += 1;

            _onPlayerHpChanged?.Invoke(_currentHp);
        }
    }
}