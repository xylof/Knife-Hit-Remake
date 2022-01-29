using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public enum StageType
    {
        Normal, Boss
    }

    public class StageController
    {
        private const int BOSS_PERIOD = 5;
        private int currentStage;
        public int CurrentStage => currentStage & BOSS_PERIOD;

        public void InitController()
        {
            currentStage = 0;
        }

        public StageType NextStage()
        {
            currentStage++;

            if (currentStage % BOSS_PERIOD == 0)
                return StageType.Boss;
            return StageType.Normal;
        }
    } 
}
