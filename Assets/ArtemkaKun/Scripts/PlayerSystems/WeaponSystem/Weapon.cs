using System;
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

        public event Action OnEnemyWasKilled;

        private void Update()
        {
            if (!Api.IsTriggerPressed)
            {
                return;
            }

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, data.Range))
            {
                KillEnemy(hit.collider.gameObject);
            }
        }

        private void KillEnemy(GameObject enemy)
        {
            Destroy(enemy);

            OnEnemyWasKilled?.Invoke();
        }
    }
}