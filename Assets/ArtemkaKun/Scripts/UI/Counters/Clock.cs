using System;

namespace ArtemkaKun.Scripts.UI.Counters
{
    /// <summary>
    /// Class, that maintains clock (like round clock).
    /// </summary>
    public sealed class Clock : Counter<TimeSpan>
    {
        private readonly TimeSpan _oneSecondInTimeSpanForm = TimeSpan.FromSeconds(1);
        
        /// <summary>
        /// Increment clock's time on 1 second.
        /// </summary>
        public override void IncrementCounter()
        {
            counterValue = counterValue.Add(_oneSecondInTimeSpanForm);
            
            base.IncrementCounter();
        }
    }
}