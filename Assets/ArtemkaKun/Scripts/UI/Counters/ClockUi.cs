using System;
using ArtemkaKun.Scripts.ClockSystems;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI.Counters
{
    /// <summary>
    /// Class, that maintains clock's UI only.
    /// </summary>
    public sealed class ClockUi : Counter<TimeSpan>
    {
        [SerializeField] private ClockManager relatedClockManager;

        /// <summary>
        /// Adds provided time (in seconds) to the clock.
        /// </summary>
        /// <param name="passedTime">Time to add (in seconds).</param>
        public void AddTimeToClock(float passedTime)
        {
            counterValue = counterValue.Add(TimeSpan.FromSeconds(passedTime));
            
            IncrementCounter();
        }
        
        /// <summary>
        /// Stops clock and reset its value.
        /// </summary>
        public override void ResetCounter()
        {
            relatedClockManager.ActivateClock(false);
            
            base.ResetCounter();
        }
    }
}