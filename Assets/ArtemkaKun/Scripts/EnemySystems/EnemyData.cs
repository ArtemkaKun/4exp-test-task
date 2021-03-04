﻿using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    ///     Scriptable Object, that stores enemy data.
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableObjects/EnemyData", menuName = "ScriptableObjects/EnemyData", order = 0)]
    public sealed class EnemyData : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private AudioClip enemyDiesSound;
        [SerializeField] private AudioClip enemyAttackSound;

        public float Speed => speed;

        public AudioClip EnemyDiesSound => enemyDiesSound;

        public AudioClip EnemyAttackSound => enemyAttackSound;
    }
}