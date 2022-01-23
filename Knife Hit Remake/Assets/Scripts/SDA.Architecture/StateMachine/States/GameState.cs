using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using SDA.Input;
using SDA.Generation;
using SDA.CoreGameplay;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator, ShieldMovementController shieldMovementController, KnifeThrower knifeThrower)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
        }

        public override void InitState()
        {
            if (gameView != null)
                gameView.ShowView();


            BaseShield startShield = levelGenerator.SpawnShield();
            shieldMovementController.InitializeShield(startShield);

            Knife knife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(knife);

            inputSystem.AddListener(knifeThrower.Throw);
        }

        public override void UpdateState()
        {
            inputSystem.UpdateSystem();
            shieldMovementController.UpdateController();
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
