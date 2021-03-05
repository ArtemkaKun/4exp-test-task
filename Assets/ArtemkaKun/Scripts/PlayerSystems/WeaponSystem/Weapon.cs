using System;
using ArtemkaKun.Scripts.EnemySystems;
using Google.XR.Cardboard;
using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems.WeaponSystem
{
    /// <summary>
    ///     Class, that maintains player's weapon.
    /// </summary>
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData data;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private AudioSource weaponAudioSource;

        public event Action OnEnemyWasKilled;

        private void Awake()
        {
            weaponAudioSource.clip = data.FireSound;
        }

        private void Update()
        {
            if (!Api.IsTriggerPressed)
            {
                return;
            }

            weaponAudioSource.Play();

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, data.Range))
            {
                KillEnemy(hit.collider.gameObject);
            }
        }

        private void KillEnemy(GameObject enemy)
        {
            enemy.GetComponent<Enemy>().OnDie();

            Destroy(enemy);

            OnEnemyWasKilled?.Invoke();
        }
    }
}