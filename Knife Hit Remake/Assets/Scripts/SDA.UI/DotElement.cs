using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SDA.UI
{
    public class DotElement : MonoBehaviour
    {
        [SerializeField]
        private Image dotImage;

        public void MarkAsUnlocked()
        {
            dotImage.DOColor(Color.green, 0.7f);
        }

        public void MarkAsLocked()
        {
            dotImage.color = Color.white;
        }
    } 
}
