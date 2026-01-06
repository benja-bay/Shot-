using Core.StateMachine;
using Core.States;
using UnityEngine;

// CORE SYSTEM – NOT USED YET

namespace Core.GameFlow
{
    public class GameController : MonoBehaviour
    {
        private GameStateMachine stateMachine;
        private GameContext context;

        private void Awake()
        {
            stateMachine = new GameStateMachine();
            context = new GameContext(stateMachine);
        }

        private void Start()
        {
            stateMachine.ChangeState(new LobbyState(context));
        }

        private void Update()
        {
            stateMachine.Tick();
        }
    }
}

