using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.PlayerSystems.WeaponSystem
{
    /// <summary>
    /// Class, that maintains player's weapon.
    /// </summary>
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponData data;
        [SerializeField] private Camera playerCamera;

        private void Update()
        {
            if (!Google.XR.Cardboard.Api.IsTriggerPressed)
            {
                return;
            }

            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out var hit, data.Range))
            {
                Destroy(hit.collider.gameObject); 
            }
        }
    }
}