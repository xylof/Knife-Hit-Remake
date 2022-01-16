using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using SDA.Input;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;

        public GameState(GameView gameView, InputSystem inputSystem)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
        }

        public override void InitState()
        {
            if (gameView != null)
                gameView.ShowView();

            inputSystem.AddListener(PrintDebug);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
        }

        public override void DestroyState()
        {
            if (gameView != null)
                gameView.HideView();

            inputSystem.RemoveAllListeners();
        }

        private void PrintDebug()
        {
            Debug.Log("button");
        }
    } 
}
