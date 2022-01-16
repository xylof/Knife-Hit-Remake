using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SDA.Architecture
{
    public class GameController : MonoBehaviour
    {
        private MenuState menuState;

        private BaseState currentlyActiveState;

        private void Start()
        {
            menuState = new MenuState();

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
