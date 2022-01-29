using UnityEngine;
using SDA.UI;
using UnityEngine.Events;

namespace SDA.Architecture
{
    public class MenuState : BaseState
    {
        private MenuView menuView;
        private UnityAction transitionToGameState;
        private UnityAction transitionToSettingsState;

        public MenuState(UnityAction transitionToGameState, UnityAction transitionToSettingsState, MenuView menuView)
        {
            this.menuView = menuView;
            this.transitionToGameState = transitionToGameState;
            this.transitionToSettingsState = transitionToSettingsState;
        }

        public override void InitState()
        {
            Debug.Log("init menu");

            if (menuView != null)
                menuView.ShowView();

            menuView.PlayButton.onClick.AddListener(transitionToGameState);
            menuView.SettingsButton.onClick.AddListener(transitionToSettingsState);
        }

        public override void UpdateState()
        {

        }

        public override void DestroyState()
        {
            if (menuView != null)
                menuView.HideView();

            menuView.PlayButton.onClick.RemoveAllListeners();
            menuView.SettingsButton.onClick.RemoveAllListeners();
        }
    }
}
