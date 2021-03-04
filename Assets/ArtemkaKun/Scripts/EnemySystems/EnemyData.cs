using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    /// Scriptable Object, that stores enemy data.
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects/EnemyData", menuName = "ScriptableObjects/EnemyData", order = 0)]
    public sealed class EnemyData : ScriptableObject
    {
        public float Speed => speed;

        [SerializeField] private float speed;
    }
}