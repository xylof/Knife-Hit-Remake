using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SDA.UI
{
    public class GameView : BaseView
    {
        [SerializeField]
        private TextMeshProUGUI scoreInfo;

        //public TextMeshProUGUI ScoreInfo => scoreInfo;

        public void UpdateScore(int points)
        {
            scoreInfo.text = points.ToString();
        }
    } 
}
