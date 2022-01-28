using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class MenuView : BaseView
    {
        [SerializeField]
        private Button playButton;

        [SerializeField]
        private Button settingsButton;

        public Button PlayButton => playButton; // Ten zapis dzia³a tak samo jak getter
        public Button SettingsButton => settingsButton;
    } 
}
