using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Stats
{
    public class StatsView: MonoBehaviour
    {
        [SerializeField] private TMP_Text countWin;
        public TMP_Text CountWin => countWin;
        [SerializeField] private TMP_Text countLose;
        public TMP_Text CountLose => countLose;
        [SerializeField] private GameObject resultPanel;
        public GameObject ResultPanel => resultPanel;
        [SerializeField] private Button resultBtn;
        public Button ResultBtn => resultBtn;
    }
}