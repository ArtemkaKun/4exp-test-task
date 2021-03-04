using System.Collections;
using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    ///     Class, that controls enemy spawner.
    /// </summary>
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private float spawnFrequencyInSeconds;
        [SerializeField] private float spawnRadius;
        [SerializeField] private float minYCoordinate;
        [SerializeField] private GameObject enemyPrefab;

        private bool _isSpawnerActive;

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
                yield return new WaitForSeconds(spawnFrequencyInSeconds);

                var randomPointOnSphere = Random.onUnitSphere * spawnRadius;

                ClampYCoordinate(ref randomPointOnSphere);

                var newEnemy = Instantiate(enemyPrefab);

                newEnemy.transform.position = randomPointOnSphere;

                newEnemy.transform.LookAt(Vector3.zero);
            }
        }

        private void ClampYCoordinate(ref Vector3 randomPointOnSphere)
        {
            if (randomPointOnSphere.y < minYCoordinate)
            {
                randomPointOnSphere.y = minYCoordinate;
            }
        }

        /// <summary>
        ///     Stop enemy spawn.
        /// </summary>
        public void StopSpawner()
        {
            _isSpawnerActive = false;
        }
    }
}