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

        /// <summary>
        /// Set new value for the round clock.
        /// </summary>
        /// <param name="newRoundTime">New rounds clock time.</param>
        public void ChangeRoundClockValue(TimeSpan newRoundTime)
        {
            roundClockUi.SetCounterValueToText(newRoundTime);
        }

        /// <summary>
        /// Changes value of the HP bar.
        /// </summary>
        public void ChangePlayerHp(int newValue)
        {
            hpBar.SetHpValue(newValue);
        }
    }
}