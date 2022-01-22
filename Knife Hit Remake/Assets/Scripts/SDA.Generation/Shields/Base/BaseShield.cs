using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Generation
{
    public abstract class BaseShield : MonoBehaviour
    {
        [SerializeField]
        protected ShieldMovementStep[] movementScheme;

        public abstract void Initialize();
        public abstract void Rotate();
    } 
}
