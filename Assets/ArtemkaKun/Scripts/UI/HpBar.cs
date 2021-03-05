using UnityEngine;
using UnityEngine.UI;

namespace ArtemkaKun.Scripts.UI
{
    /// <summary>
    ///     Class, that maintains hp bar.
    /// </summary>
    public sealed class HpBar : MonoBehaviour
    {
        [SerializeField] private Slider bar;

        /// <summary>
        ///     Set bar bounds.
        /// </summary>
        public void Initialize(Vector2Int newBarBounds)
        {
            bar.minValue = newBarBounds.x;
            bar.maxValue = newBarBounds.y;
        }

        /// <summary>
        ///     Set new hp value
        /// </summary>
        public void SetHpValue(int newValue)
        {
            bar.value = newValue;
        }
    }
}