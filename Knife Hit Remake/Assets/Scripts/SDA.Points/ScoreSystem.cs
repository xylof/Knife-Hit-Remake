using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Points
{
    public class ScoreSystem
    {
        private int currentPoints;
        public int CurrentPoints => currentPoints;

        public void InitSystem()
        {
            currentPoints = 0;
        }

        public void IncreasePoints()
        {
            currentPoints++;
        }
    } 
}
