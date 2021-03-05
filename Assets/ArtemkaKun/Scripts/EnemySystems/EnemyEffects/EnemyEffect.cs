using System;
using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems.EnemyEffects
{
    /// <summary>
    /// Base class, that represents enemy effect.
    /// </summary>
    [Serializable]
    public abstract class EnemyEffect : MonoBehaviour
    {
        [SerializeField] private EnemyEffectActivationTime activationTime;

        public EnemyEffectActivationTime ActivationTime => activationTime;

        public abstract void ActivateEffect();
    }
}