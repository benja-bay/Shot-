using Core.GameFlow;
using Core.StateMachine;
using UnityEngine;

// CORE SYSTEM – NOT USED YET

namespace Core.States
{
    public class LobbyState : IGameState
    {
        private GameContext context;

        public LobbyState(GameContext context)
        {
            this.context = context;
        }

        public void Enter()
        {
            Debug.Log("Lobby Enter");
            // Mostrar UI lobby
        }

        public void Exit()
        {
            // Ocultar UI lobby
        }

        public void Tick()
        {
            // Esperar input: Start Game
        }
    }
}