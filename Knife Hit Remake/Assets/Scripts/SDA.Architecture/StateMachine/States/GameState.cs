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
using DG.Tweening;

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

        private UnityAction toLoseStateTransition;

        public GameState(GameView gameView, InputSystem inputSystem, LevelGenerator levelGenerator, ShieldMovementController shieldMovementController, KnifeThrower knifeThrower, ScoreSystem scoreSystem, StageController stageController, UnityAction toLoseStateTransition)
        {
            this.gameView = gameView;
            this.inputSystem = inputSystem;
            this.levelGenerator = levelGenerator;
            this.shieldMovementController = shieldMovementController;
            this.knifeThrower = knifeThrower;
            this.scoreSystem = scoreSystem;
            this.stageController = stageController;
            this.toLoseStateTransition = toLoseStateTransition;
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

            shieldMovementController.DisposeShield();
            inputSystem.RemoveAllListeners();
        }

        private void PrepareNewKnife()
        {
            Knife newKnife = levelGenerator.SpawnKnife();
            newKnife.InitKnife(() => LoseGame(newKnife));
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
            gameView.UpdateStage(stageController.CurrentStageModulo);
        }

        private void LoseGame(Knife lastKnife)
        {
            inputSystem.RemoveAllListeners();

            lastKnife.Rigidbody2D.gravityScale = 1f;
            lastKnife.Rigidbody2D.freezeRotation = false;
            lastKnife.Rigidbody2D.AddTorque(5f, ForceMode2D.Impulse); // Nadajemy rotacjê no¿owi

            var loseSequence = DOTween.Sequence();
            loseSequence
                .SetDelay(1f)
                .OnComplete(() => DestroyKnifeAndProceed(lastKnife));       
        }

        private void DestroyKnifeAndProceed(Knife lastKnife)
        {
            lastKnife.DestroyKnife();
            toLoseStateTransition.Invoke();
        }
    }
}
