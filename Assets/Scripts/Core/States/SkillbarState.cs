using Core.GameFlow;
using Core.StateMachine;
using UnityEngine;

// CORE SYSTEM – NOT USED YET

namespace Core.States
{
    public class SkillbarState : IGameState
    {
        private GameContext context;

        public SkillbarState(GameContext context)
        {
            this.context = context;
        }

        public void Enter()
        {
            Debug.Log("Skillbar Start");
        }

        public void Exit() { }

        public void Tick()
        {
            // Resolver éxito / fallo
        }
    }
}