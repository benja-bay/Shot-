using Core.StateMachine;

// CORE SYSTEM – NOT USED YET

namespace Core.GameFlow
{
    public class GameContext
    {
        public PlayerStats PlayerStats { get; private set; }
        public GameStateMachine StateMachine { get; private set; }

        public GameContext(GameStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            PlayerStats = new PlayerStats();
        }
    }
}