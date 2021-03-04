using System;
using TMPro;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI.Counters
{
    /// <summary>
    /// Base class for every UI counter that contains methods and data to maintain counter in easy way.
    /// </summary>
    public class Counter<T> : MonoBehaviour
        where T : IFormattable
    {
        protected T counterValue;
        
        [SerializeField] private TMP_Text counterText;
        [SerializeField] private string counterTextFormat;

        /// <summary>
        /// Resets counter to it's default value.
        /// </summary>
        public void ResetCounter()
        {
            counterValue = default;

            SetCounterValueToText();
        }

        /// <summary>
        /// Increments value of counter of the one unit. Attention - inheritors need to implement counter value increment!
        /// </summary>
        public virtual void IncrementCounter()
        {
            SetCounterValueToText();
        }

        private void SetCounterValueToText()
        {
            counterText.text = counterValue.ToString(counterTextFormat, null);
        }
    }
}