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

        public Button PlayButton => playButton; // Ten zapis dzia�a tak samo jak getter
    } 
}
