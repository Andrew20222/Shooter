using UnityEngine;
using System.Collections.Generic;

namespace Inventories
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Guns.Gun> guns = new();
        private int currentItemIndex = 0;

        private void Start()
        {
            SetActiveGun(currentItemIndex);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwitchToItem(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwitchToItem(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwitchToItem(2);
            }
        }

        private void SwitchToItem(int index)
        {
            if (index >= 0 && index < guns.Count)
            {
                currentItemIndex = index;
                SetActiveGun(currentItemIndex);
            }
        }

        private void SetActiveGun(int index)
        {
            for (int i = 0; i < guns.Count; i++)
            {
                if (i == index)
                {
                    guns[i].gameObject.SetActive(true);
                }
                else
                {
                    guns[i].gameObject.SetActive(false);
                }
            }
        }
    }
}