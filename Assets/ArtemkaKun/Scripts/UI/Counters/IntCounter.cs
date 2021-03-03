namespace ArtemkaKun.Scripts.UI.Counters
{
    /// <summary>
    /// Class, that maintains int counters (like kills counter).
    /// </summary>
    public sealed class IntCounter : Counter<int>
    {
        /// <summary>
        /// Increments counter on 1.
        /// </summary>
        public override void IncrementCounter()
        {
            counterValue++;
            
            base.IncrementCounter();
        }
    }
}