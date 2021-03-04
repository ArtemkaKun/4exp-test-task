using ArtemkaKun.Scripts.UI.Counters;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI
{
    /// <summary>
    /// Class, that manages round UI in the game.
    /// </summary>
    public sealed class RoundUi : MonoBehaviour
    {
        [SerializeField] private IntCounter killsCounter;
        [SerializeField] private ClockUi roundClockUi;
        [SerializeField] private HpBar hpBar;
        
        /// <summary>
        /// Initialize UI subscriptions and members. Should be used instead of Awake() method.
        /// </summary>
        public void Initialize(Vector2Int hpBarBounds)
        {
            hpBar.Initialize(hpBarBounds);
        }

        private void AddOneKill()
        {
            killsCounter.IncrementCounter();
        }

        /// <summary>
        /// Adds passed time to the round clock.
        /// </summary>
        /// <param name="passedTime">How many seconds were passed.</param>
        public void AddTimeToRoundClock(float passedTime)
        {
            roundClockUi.AddTimeToClock(passedTime);
        }

        /// <summary>
        /// Changes value of the HP bar.
        /// </summary>
        public void RegisterPlayerDamage()
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
