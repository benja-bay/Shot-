using Core.GameFlow;
using Core.StateMachine;
using UnityEngine;

// CORE SYSTEM – NOT USED YET

namespace Core.States
{
    public class DelayState : IGameState
    {
        private GameContext context;
        private float duration;
        private float timer;

        public DelayState(GameContext context, float duration)
        {
            this.context = context;
            this.duration = duration;
        }

        public void Enter()
        {
            timer = 0f;
        }

        public void Exit() { }

        public void Tick()
        {
            timer += Time.deltaTime;
            if (timer >= duration)
            {
                context.StateMachine.ChangeState(
                    new SkillbarState(context)
                );
            }
        }
    }
}