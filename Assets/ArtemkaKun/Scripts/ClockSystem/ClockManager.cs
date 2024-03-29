﻿using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.ClockSystem
{
    /// <summary>
    ///     Class, that maintains clock (like round clock).
    /// </summary>
    public sealed class ClockManager : MonoBehaviour
    {
        private TimeSpan _clockValue;
        private bool _isClockActive;

        private Action<TimeSpan> _onTimeChanged;

        public TimeSpan ClockValue => _clockValue;

        private void Update()
        {
            if (!_isClockActive)
            {
                return;
            }

            _clockValue = _clockValue.Add(TimeSpan.FromSeconds(Time.deltaTime));

            _onTimeChanged?.Invoke(_clockValue);
        }

        /// <summary>
        ///     Initialize delegate connected to the clock UI.
        /// </summary>
        /// <param name="onTimePassesDelegate"></param>
        public void Initialize(Action<TimeSpan> onTimePassesDelegate)
        {
            _onTimeChanged = onTimePassesDelegate;
        }

        /// <summary>
        ///     Activate or deactivate clock depends on provided parameter.
        /// </summary>
        /// <param name="newStatus">True - activate clock; false - deactivate</param>
        public void ActivateClock(bool newStatus)
        {
            _isClockActive = newStatus;
        }

        /// <summary>
        ///     Reset clock's value.
        /// </summary>
        public void ResetValue()
        {
            ActivateClock(false);

            _clockValue = default;

            _onTimeChanged?.Invoke(_clockValue);
        }
    }
}