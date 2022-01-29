using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class DotElement : MonoBehaviour
    {
        [SerializeField]
        private Image dotImage;

        public void MarkAsUnlocked()
        {
            dotImage.color = Color.yellow;
        }

        public void MarkAsLocked()
        {
            dotImage.color = Color.white;
        }
    } 
}
