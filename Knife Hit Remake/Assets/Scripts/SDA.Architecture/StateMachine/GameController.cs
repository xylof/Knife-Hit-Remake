using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SDA.UI;
using UnityEngine.Events;
using SDA.Input;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private MenuView menuView;

        [SerializeField]
        private GameView gameView;

        private InputSystem inputSystem;

        private MenuState menuState;
        private GameState gameState;

        private BaseState currentlyActiveState;

        private UnityAction toGameStateTransition;

        private void Start()
        {
            toGameStateTransition = () => ChangeState(gameState);

            inputSystem = new InputSystem();

            menuState = new MenuState(toGameStateTransition, menuView);
            gameState = new GameState(gameView, inputSystem);

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
