using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems.WeaponSystem
{
    /// <summary>
    /// Scriptable Object, that store player's weapon data.
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects/WeaponData", menuName = "ScriptableObjects/WeaponData", order = 0)]
    public sealed class WeaponData : ScriptableObject
    {
        public float Range => range;

        [SerializeField] private float range;
    }
}