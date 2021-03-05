using System;
using TMPro;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI.Counters
{
    /// <summary>
    ///     Base class for every UI counter that contains methods and data to maintain counter in easy way.
    /// </summary>
    public class Counter<T> : MonoBehaviour
        where T : IFormattable
    {
        [SerializeField] private TMP_Text counterText;
        [SerializeField] private string counterTextFormat;

        /// <summary>
        ///     Set new value of counter.
        /// </summary>
        /// <param name="newCounterValue">New value of counter.</param>
        public void SetCounterValueToText(T newCounterValue)
        {
            counterText.text = newCounterValue.ToString(counterTextFormat, null);
        }
    }
}