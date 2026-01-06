/* using Core.Events;
using Core.GameFlow;
using Core.StateMachine;
using Gameplay.Minigames.ShotGrab.Core;

namespace Core.States
{
    public class ShotGrabState : IGameState
    {
        private GameContext context;
        private ShotGrabController controller;

        public ShotGrabState(GameContext context, ShotGrabController controller)
        {
            this.context = context;
            this.controller = controller;
        }

        public void Enter()
        {
            GameEvents.OnShotGrabbed += OnShotGrabbed;
            controller.StartGame(context.PlayerStats.Score);
        }

        public void Exit()
        {
            GameEvents.OnShotGrabbed -= OnShotGrabbed;
            controller.StopGame();
        }

        public void Tick() { }

        private void OnShotGrabbed()
        {
            context.StateMachine.ChangeState(
                new DelayState(context, 1.5f)
            );
        }
    }
} */