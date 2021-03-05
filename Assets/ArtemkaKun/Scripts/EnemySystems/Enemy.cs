using ArtemkaKun.Scripts.EnemySystems.EnemyEffects;
using UnityEngine;

namespace ArtemkaKun.Scripts.EnemySystems
{
    /// <summary>
    ///     Class, that controls enemy unit.
    /// </summary>
    public sealed class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyData data;

        private void Update()
        {
            transform.Translate(transform.forward * (data.Speed * Time.deltaTime), Space.World);
        }

        /// <summary>
        /// This function should be called only when enemy dies.
        /// </summary>
        public void OnDie()
        {
            PlayDieSound();

            ActivateEnemyEffects(EnemyEffectActivationTime.OnKilled);
        }

        private void PlayDieSound()
        {
            if (!data.EnemyDiesSound)
            {
                return;
            }

            AudioSource.PlayClipAtPoint(data.EnemyDiesSound, transform.position);
        }

        private void ActivateEnemyEffects(EnemyEffectActivationTime activationTime)
        {
            foreach (var enemyEffect in data.EnemyEffects)
            {
                if (enemyEffect.ActivationTime != activationTime)
                {
                    continue;
                }

                enemyEffect.ActivateEffect();
            }
        }

        /// <summary>
        /// Play monster attack sound.
        /// </summary>
        public void PlayAttackSound()
        {
            if (!data.EnemyAttackSound)
            {
                return;
            }

            AudioSource.PlayClipAtPoint(data.EnemyAttackSound, transform.position);
        }
    }
}