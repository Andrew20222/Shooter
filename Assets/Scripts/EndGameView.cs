using System;
using UnityEngine;
using Mechanics.Healths;
using Units;

namespace Runners
{
    public class EndGameView : MonoBehaviour
    {
        public Action ShowPanelWin;
        public Action ShowPanelLose;

        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject losePanel;

        private Health _player;
        private Health _enemy;

        public void Initialize(Health player, Health enemy)
        {
            _player = player;
            _player.GetComponent<PlayerController>();
            _enemy = enemy;

            _player.Dead += ShowLosePanel;
            _enemy.Dead += ShowWinPanel;
        }

        private void ShowWinPanel()
        {
            winPanel.SetActive(true);
            ShowPanelWin?.Invoke();
        }
        
        private void ShowLosePanel()
        {
            losePanel.SetActive(true);
            ShowPanelLose?.Invoke();
        }

        private void OnDisable()
        {
            _player.Dead -= ShowLosePanel;
            _enemy.Dead -= ShowWinPanel;
        }
    }
}