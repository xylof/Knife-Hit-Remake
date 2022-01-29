using SDA.Architecture;
using SDA.Generation;
using SDA.Points;
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
        private ScoreSystem scoreSystem;
        private StageController stageController;

        private UnityAction toMenuTransition;
        private UnityAction toGameTransition;

        public LoseState(LoseView loseView, UnityAction toMenuTransition, UnityAction toGameTransition, ScoreSystem scoreSystem, StageController stageController)
        {
            this.loseView = loseView;
            this.toMenuTransition = toMenuTransition;
            this.toGameTransition = toGameTransition;
            this.scoreSystem = scoreSystem;
            this.stageController = stageController;
        }

        public override void InitState()
        {
            if (loseView != null)
                loseView.ShowView();

            loseView.RestartButton.onClick.AddListener(toGameTransition);
            loseView.MenuButton.onClick.AddListener(toMenuTransition);
            loseView.UpdatePointsAndStage(scoreSystem.CurrentPoints, stageController.CurrentStage);
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
