using SDA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SDA.UI
{
    public class SettingsView : BaseView
    {
        [SerializeField]
        private Button backButton;

        public Button BackButton => backButton;
    } 
}
