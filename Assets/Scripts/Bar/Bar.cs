using UnityEngine;
using UnityEngine.UI;

namespace Bar
{
    public abstract class Bar: MonoBehaviour
    {
        [SerializeField] private Image _filler;
        [SerializeField] private GameObject winPanel;
        protected void OnValueChanged(float valueInParts)
        {
            _filler.fillAmount = valueInParts;
        }

        protected void TimerOver()
        {
            winPanel.SetActive(true);
        }
    }
}