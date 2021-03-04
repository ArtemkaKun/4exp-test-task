using System;
using ArtemkaKun.Scripts.UI.Counters;
using TMPro;
using UnityEngine;

namespace ArtemkaKun.Scripts.UI
{
    /// <summary>
    ///     Class, that manages round UI in the game.
    /// </summary>
    public sealed class RoundUi : MonoBehaviour
    {
        [SerializeField] private IntCounter killsCounter;
        [SerializeField] private ClockUi roundClockUi;
        [SerializeField] private HpBar hpBar;
        [SerializeField] private GameObject inGameCanvas;
        [SerializeField] private GameObject roundFailedCanvas;
        [SerializeField] private TMP_Text roundScoreText;

        /// <summary>
        ///     Initialize UI members. Should be used instead of Awake() method.
        /// </summary>
        public void Initialize(Vector2Int hpBarBounds)
        {
            hpBar.Initialize(hpBarBounds);
        }

        /// <summary>
        ///     Change value of enemy kills.
        /// </summary>
        /// <param name="newKillsValue">New value of kills.</param>
        public void ChangeKilledEnemiesCount(int newKillsValue)
        {
            killsCounter.SetCounterValueToText(newKillsValue);
        }

        /// <summary>
        ///     Set new value for the round clock.
        /// </summary>
        /// <param name="newRoundTime">New rounds clock time.</param>
        public void ChangeRoundClockValue(TimeSpan newRoundTime)
        {
            roundClockUi.SetCounterValueToText(newRoundTime);
        }

        /// <summary>
        ///     Changes value of the HP bar.
        /// </summary>
        public void ChangePlayerHp(int newValue)
        {
            hpBar.SetHpValue(newValue);
        }

        /// <summary>
        ///     Activate in game canvas, deactivate failed round canvas.
        /// </summary>
        public void ActivateInGameCanvas()
        {
            inGameCanvas.SetActive(true);

            roundFailedCanvas.SetActive(false);
        }

        /// <summary>
        ///     Activate in failed round canvas, deactivate in game UI canvas.
        /// </summary>
        public void ActivateFailedRoundCanvas()
        {
            inGameCanvas.SetActive(false);

            roundFailedCanvas.SetActive(true);
        }

        /// <summary>
        ///     Set round score to field, that will be showed on the failed round screen.
        /// </summary>
        /// <param name="score">Round score.</param>
        public void SetRoundScore(int score)
        {
            roundScoreText.text = $"Your score is - {score.ToString()} points";
        }
    }
}