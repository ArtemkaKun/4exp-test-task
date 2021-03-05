using System.Collections;
using System.Linq;
using ArtemkaKun.Scripts.Helpers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ArtemkaKun.Scripts.EnemySystems.SpawnSystem
{
    /// <summary>
    ///     Class, that controls enemy spawner.
    /// </summary>
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Vector2 spawnFrequencyBounds;
        [SerializeField] private float spawnFunctionSmoothCoefficient = 0.01f;
        [SerializeField] private float spawnRadius;
        [SerializeField] private Vector2 yCoordinateBounds;
        [SerializeField] private EnemySpawnRecord[] enemySpawnRecords;

        private bool _isSpawnerActive;
        private float _spawnRate;

        /// <summary>
        /// Initialize manager's members.
        /// </summary>
        public void Initialize()
        {
            _spawnRate = spawnFrequencyBounds.y;
        }

        /// <summary>
        ///     Activate spawner and start spawn enemies.
        /// </summary>
        public void StartSpawner()
        {
            _isSpawnerActive = true;

            StartCoroutine(SpawnEnemy());
        }

        private IEnumerator SpawnEnemy()
        {
            while (_isSpawnerActive)
            {
                yield return new WaitForSeconds(_spawnRate);

                var newEnemy = Instantiate(GetRandomEnemy());

                newEnemy.transform.position = ConvertPointTo3dSpace(GetRandomPointOnCircleEdge());

                newEnemy.transform.LookAt(Vector3.zero);
            }
        }

        private GameObject GetRandomEnemy()
        {
            var randomValue = Random.Range(0f, 1f);

            var matchedToSpawnEnemies = enemySpawnRecords
                .Where(enemyRecord => enemyRecord.spawnChance >= randomValue);

            if (matchedToSpawnEnemies.Count() == 0)
            {
                return enemySpawnRecords.GetRandomElement().enemyPrefab;
            }

            return matchedToSpawnEnemies.GetRandomElement().enemyPrefab;
        }

        private Vector2 GetRandomPointOnCircleEdge()
        {
            var randomDirection = Random.insideUnitCircle.normalized;

            return randomDirection * spawnRadius;
        }

        private Vector3 ConvertPointTo3dSpace(Vector2 randomPointOnSphere)
        {
            return new Vector3(randomPointOnSphere.x, Random.Range(yCoordinateBounds.x, yCoordinateBounds.y),
                randomPointOnSphere.y);
        }

        /// <summary>
        ///     Stop enemy spawn.
        /// </summary>
        public void StopSpawner()
        {
            _isSpawnerActive = false;
        }

        /// <summary>
        /// Recalculates spawn frequency with modified cubic square formula.
        /// </summary>
        /// <param name="roundTimeInSeconds">Current duration of round in seconds.</param>
        public void RecalculateSpawnRate(float roundTimeInSeconds)
        {
            var newSpawnFrequency = -Mathf.Pow(roundTimeInSeconds * spawnFunctionSmoothCoefficient, 1f / 3f) +
                                    spawnFrequencyBounds
                                        .y; //formula is -cbrt(currentRoundTime * smoothCoefficient) + maxAllowedSpawnTime

            _spawnRate = Mathf.Clamp(newSpawnFrequency, spawnFrequencyBounds.x, spawnFrequencyBounds.y);
        }
    }
}