using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    /// Class, that controls enemy unit.
    /// </summary>
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;

        private void Update()
        {
            transform.Translate(transform.forward * (data.Speed * Time.deltaTime), Space.World);
        }
    }
}