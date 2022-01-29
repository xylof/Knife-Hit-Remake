using SDA.Architecture;
using SDA.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class LoseState : BaseState
    {
        private LoseView loseView;
        private UnityAction toMenuTransition;
        private UnityAction toGameTransition;

        public LoseState(LoseView loseView, UnityAction toMenuTransition, UnityAction toGameTransition)
        {
            this.loseView = loseView;
            this.toMenuTransition = toMenuTransition;
            this.toGameTransition = toGameTransition;
        }

        public override void InitState()
        {
            if (loseView != null)
                loseView.ShowView();

            loseView.RestartButton.onClick.AddListener(toGameTransition);
            loseView.MenuButton.onClick.AddListener(toMenuTransition);
        }

        public override void UpdateState()
        {
            
        }

        public override void DestroyState()
        {
            loseView.RestartButton.onClick.RemoveAllListeners();
            loseView.MenuButton.onClick.RemoveAllListeners();

            if (loseView != null)
                loseView.HideView();
        }
    } 
}
