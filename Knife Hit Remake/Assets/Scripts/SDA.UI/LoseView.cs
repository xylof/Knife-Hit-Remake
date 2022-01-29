using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class LoseView : BaseView
    {
        [SerializeField]
        private Button restartButton;
        public Button RestartButton => restartButton;

        [SerializeField]
        private Button menuButton;
        public Button MenuButton => menuButton;
    } 
}