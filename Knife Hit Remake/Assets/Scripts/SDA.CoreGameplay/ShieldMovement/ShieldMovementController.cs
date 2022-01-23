using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.Generation;

namespace SDA.CoreGameplay
{
    public class ShieldMovementController
    {
        private BaseShield currentlyActiveShield;

        public void InitializeShield(BaseShield newShield)
        {
            currentlyActiveShield = newShield;
            currentlyActiveShield.Initialize();
        }

        public void UpdateController()
        {
            if (currentlyActiveShield != null)
                currentlyActiveShield.Rotate();
        }
    } 
}
