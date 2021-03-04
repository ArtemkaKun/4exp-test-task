using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.ClockSystems
{
    /// <summary>
    /// Class, that maintains clock (like round clock).
    /// </summary>
    public sealed class ClockManager : MonoBehaviour
    {
        private Action<float> _onTimePassed;
        private bool _isClockActive;

        /// <summary>
        /// Initialize delegate connected to the clock UI.
        /// </summary>
        /// <param name="onTimePassesDelegate"></param>
        public void Initialize(Action<float> onTimePassesDelegate)
        {
            _onTimePassed = onTimePassesDelegate;
        }

        /// <summary>
        /// Activate or deactivate clock depends on provided parameter.
        /// </summary>
        /// <param name="newStatus">True - activate clock; false - deactivate</param>
        public void ActivateClock(bool newStatus)
        {
            _isClockActive = newStatus;
        }

        private void Update()
        {
            if (!_isClockActive)
            {
                return;
            }
            
            _onTimePassed?.Invoke(Time.deltaTime);
        }
    }
}