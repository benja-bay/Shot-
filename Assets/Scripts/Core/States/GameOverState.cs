using Core.GameFlow;
using Core.StateMachine;
using UnityEngine;

// CORE SYSTEM – NOT USED YET

namespace Core.States
{
    public class GameOverState : IGameState
    {
        private GameContext context;

        public GameOverState(GameContext context)
        {
            this.context = context;
        }

        public void Enter()
        {
            Debug.Log("Game Over");
            // Animación vómito
        }

        public void Exit() { }

        public void Tick()
        {
            // Volver al lobby
            context.StateMachine.ChangeState(
                new LobbyState(context)
            );
        }
    }
}