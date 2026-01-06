
// CORE SYSTEM – NOT USED YET

namespace Core.StateMachine
{
    public class GameStateMachine
    {
        private IGameState currentState;

        public void ChangeState(IGameState newState)
        {
            currentState?.Exit();
            currentState = newState;
            currentState.Enter();
        }

        public void Tick()
        {
            currentState?.Tick();
        }
    }
}