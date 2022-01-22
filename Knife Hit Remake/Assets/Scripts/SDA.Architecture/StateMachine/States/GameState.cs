using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using SDA.Input;
using SDA.Generation;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
        }

        public override void InitState()
        {
            if (gameView != null)
                gameView.ShowView();

            levelGenerator.SpawnShield();
            levelGenerator.SpawnKnife();
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
