using System;
using ArtemkaKun.Scripts.GameSystems;

namespace ArtemkaKun.Scripts.EnemySystems.EnemyEffects
{
    /// <summary>
    /// Class, that stores data and methods of hp add effect.
    /// </summary>
    [Serializable]
    public sealed class PlayerHpContainer : EnemyEffect
    {
        public override void ActivateEffect()
        {
            GameManager.onAddPlayerEffectFired?.Invoke();
        }
    }
}