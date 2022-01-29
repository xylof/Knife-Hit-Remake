using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using UnityEngine.Events;
using SDA.Input;
using SDA.Generation;
using SDA.CoreGameplay;
using SDA.Points;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;

        [SerializeField]
        private SettingsView settingsView;

        [SerializeField]
        private LevelGenerator levelGenearator;      

        private InputSystem inputSystem;
        private ShieldMovementController shieldMovementController;
        private KnifeThrower knifeThrower;
        private ScoreSystem scoreSystem;

        private MenuState menuState;
        private GameState gameState;
        private SettingsState settingsState;

        private BaseState currentlyActiveState;

        private UnityAction toGameStateTransition;
        private UnityAction toSettingsStateTransition;
        private UnityAction toMenuStateTransition;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);
            toSettingsStateTransition = () => ChangeState(settingsState);
            toMenuStateTransition = () => ChangeState(menuState);

            inputSystem = new InputSystem();
            shieldMovementController = new ShieldMovementController();
            knifeThrower = new KnifeThrower();
            scoreSystem = new ScoreSystem();

            menuState = new MenuState(toGameStateTransition, toSettingsStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenearator, shieldMovementController, knifeThrower, scoreSystem);
            settingsState = new SettingsState(toMenuStateTransition, settingsView);

            ChangeState(menuState);
        }

        private void Update()
        {
            currentlyActiveState?.UpdateState();
        }

        private void OnDestroy()
        {
            
        }

        private void ChangeState(BaseState newState)
        {
            currentlyActiveState?.DestroyState();
            currentlyActiveState = newState;
            currentlyActiveState?.InitState();
        }
    } 
}
