using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using SDA.Input;
using SDA.Generation;
using SDA.CoreGameplay;
using SDA.Points;
using UnityEngine.Events;
using TMPro;

namespace SDA.Architecture
{
    public class GameState : BaseState
    {
        private GameView gameView;
        private InputSystem inputSystem;
        private LevelGenerator levelGenerator;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;
        private StageController stageController;

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator, ShieldMovementController shieldMovementController, KnifeThrower knifeThrower, ScoreSystem scoreSystem, StageController stageController)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
            this.scoreSystem = scoreSystem;
            this.stageController = stageController;
        }

        public override void InitState()
        {
            if (gameView != null)
                gameView.ShowView();

            scoreSystem.InitSystem();
            stageController.InitController();
            PrepareNewShield();
            PrepareNewKnife();
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

        private void PrepareNewKnife()
        {
            Knife newKnife = levelGenerator.SpawnKnife();
            knifeThrower.SetKnife(newKnife);
        }

        private void IncrementScore()
        {
            scoreSystem.IncreasePoints();
            gameView.UpdateScore(scoreSystem.CurrentPoints);
        }

        private void PrepareNewShield()
        {
            StageType nextStageType = stageController.NextStage();
            BaseShield newShield = levelGenerator.SpawnShield(nextStageType);

            shieldMovementController.InitializeShield(newShield, (UnityAction)PrepareNewKnife + IncrementScore + gameView.DecreaseAmmo, PrepareNewShield);

            gameView.SpawnAmmo(newShield.KnivesToWin);
            gameView.UpdateStage(stageController.CurrentStage);
        }
    } 
}
