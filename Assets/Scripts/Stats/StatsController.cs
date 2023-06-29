using UnityEngine;
using Mechanics.Healths;
using Runners;
using StorageServices;

namespace Stats
{
    public class StatsController : MonoBehaviour
    {
        private const string KEY = "Key";
        
        private StatsData _statsData;
        private StatsView _statsView;
        private Health _health;
        private EndGameView _endGameView;
        private IStorageService _storageService;

        public void Initialize(StatsView statsView, StatsData statsData, EndGameView endGameView)
        {
            _storageService = new JsonToFileStorageService();
            _statsData = statsData;
            _statsView = statsView;
            _endGameView = endGameView;
            _endGameView.ShowPanelWin += UpdateCountWin;
            _endGameView.ShowPanelLose += UpdateCountLose;
            _statsView.ResultBtn.onClick.AddListener(ShowResult);
        }

        private void SetData()
        {
            var data = _storageService.Load<StatsData>(KEY);
            _statsData = data;
        }

        private void UpdateCountWin()
        {
            SetData();
            _statsData.CountWin++;
            _storageService.Save(KEY,_statsData);
        }
        
        private void UpdateCountLose()
        {
            SetData();
            _statsData.CountLose++;
            _storageService.Save(KEY,_statsData);
        }
        private void ShowResult()
        {
            _statsView.CountWin.text = $"CountWin : {_statsData.CountWin.ToString()} ";
            _statsView.CountLose.text =$"CountLose : {_statsData.CountLose.ToString()}";
            _statsView.ResultPanel.SetActive(true);
        }

        private void OnDisable()
        {
            _endGameView.ShowPanelWin -= UpdateCountWin;
            _endGameView.ShowPanelLose -= UpdateCountLose;
            _statsView.ResultBtn.onClick.RemoveListener(ShowResult);
        }
    }
}