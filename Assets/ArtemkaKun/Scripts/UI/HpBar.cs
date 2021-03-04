using UnityEngine;
using UnityEngine.UI;

namespace ArtemkaKun.Scripts.UI
{
    /// <summary>
    /// Class, that maintains hp bar.
    /// </summary>
    public sealed class HpBar : MonoBehaviour
    {
        [SerializeField] private Slider bar;

        /// <summary>
        /// Decreases on 1;
        /// </summary>
        public void DecreaseHp()
        {
            bar.value -= 1;
        }

        /// <summary>
        /// Set hp bar to its default value (max value = full hp)
        /// </summary>
        public void ResetValue()
        {
            bar.value = bar.maxValue;
        }
    }
}