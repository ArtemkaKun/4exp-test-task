using System;

namespace ArtemkaKun.Scripts.PlayerSystems
{
    /// <summary>
    ///     Class, that store and manages player's kills.
    /// </summary>
    public sealed class EnemyKillsManager
    {
        private Action<int> _onEnemyKilledCountChanged;

        public int KillsCount { get; private set; }

        /// <summary>
        ///     Initialize delegates.
        /// </summary>
        /// <param name="onEnemyKilledCountChangedDelegate">Delegate to invoke where 1 enemy was killed.</param>
        public void Initialize(Action<int> onEnemyKilledCountChangedDelegate)
        {
            _onEnemyKilledCountChanged = onEnemyKilledCountChangedDelegate;
        }

        /// <summary>
        ///     Reset value of killed enemies.
        /// </summary>
        public void Reset()
        {
            KillsCount = default;

            _onEnemyKilledCountChanged?.Invoke(KillsCount);
        }

        /// <summary>
        ///     Increment killed enemies count by 1.
        /// </summary>
        public void IncrementKilledEnemiesCount()
        {
            KillsCount += 1;

            _onEnemyKilledCountChanged?.Invoke(KillsCount);
        }
    }
}