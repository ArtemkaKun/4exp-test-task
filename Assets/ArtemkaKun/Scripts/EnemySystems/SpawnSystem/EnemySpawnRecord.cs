using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems.SpawnSystem
{
    /// <summary>
    /// Structure, that stores enemy prefab and spawn data (like spawn chance). This is the trick instead of serialize dictionary.
    /// </summary>
    [Serializable]
    public struct EnemySpawnRecord
    {
        public GameObject enemyPrefab;
        public float spawnChance;
    }
}