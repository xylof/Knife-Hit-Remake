using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using UnityEngine.Events;
using SDA.Input;
using SDA.Generation;
using SDA.CoreGameplay;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;

        [SerializeField]
        private LevelGenerator levelGenearator;

        private InputSystem inputSystem;

        private MenuState menuState;
        private GameState gameState;

        private BaseState currentlyActiveState;

        private UnityAction toGameStateTransition;

        private ShieldMovementController shieldMovementController;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);

            inputSystem = new InputSystem();
            shieldMovementController = new ShieldMovementController();

            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem, levelGenearator, shieldMovementController);

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
