
// CORE SYSTEM – NOT USED YET

namespace Core.StateMachine
{
    public interface IGameState
    {
        void Enter();
        void Exit();
        void Tick();
    }
}
