using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace SDA.UI
{
    public class KnifeElement : MonoBehaviour
    {
        [SerializeField]
        private Image image;

        public void MarkAsUnlocked()
        {
            image.color = Color.white;
        }

        public void MarkAsLocked()
        {
            image.DOColor(Color.black, 0.3f); // Zmiana koloru bêdzie trwa³a 0,3 sekundy
        }
    } 
}
