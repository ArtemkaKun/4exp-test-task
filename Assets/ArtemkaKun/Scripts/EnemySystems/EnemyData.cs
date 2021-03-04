using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    ///     Scriptable Object, that stores enemy data.
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects/EnemyData", menuName = "ScriptableObjects/EnemyData", order = 0)]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float speed;

        public float Speed => speed;
    }
}