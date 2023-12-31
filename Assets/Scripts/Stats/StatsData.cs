using System;
using UnityEngine;

namespace Stats
{
    public class StatsData
    {
        [SerializeField] private int countWin;

        public int CountWin
        {
            get => countWin;
            set => countWin = value;
        }

        [SerializeField] private int countLose;

        public int CountLose
        {
            get => countLose;
            set => countLose = value;
        }

    }
}
