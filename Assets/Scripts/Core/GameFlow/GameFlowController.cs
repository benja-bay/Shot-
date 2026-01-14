using System.Collections;
using Gameplay.Minigames.ShotGrab.Core;
using Gameplay.Minigames.Skillbar;
using UI;
using UnityEngine;

namespace Core.GameFlow
{
    // Main controller that manages the game flow and state transitions
    public class GameFlowController : MonoBehaviour
    {
        // Possible game states
        private enum GameState
        {
            Lobby,
            ShotGrab,
            Transition,
            Skillbar
        }

        /* =========================
         * REFERENCES
         * ========================= */

        [Header("Lobby")]
        [SerializeField] private LobbyController lobby;

        [Header("Minigames")]
        [SerializeField] private ShotGrabGame shotGrabGame;
        [SerializeField] private SkillbarGame skillbarGame;

        [Header("Transition")]
        [SerializeField] private float delayBeforeSkillbar = 1.5f;

        // Current state and score
        private GameState currentState;
        private int currentScore;
        
        // Subscribe to events
        private void Awake()
        {
            shotGrabGame.OnShotGrabbed += HandleShotGrabbed;
            skillbarGame.OnSkillbarFinished += HandleSkillbarFinished;
            lobby.OnPlayPressed += HandlePlayPressed;
        }

        // Start the game in the lobby state
        private void Start()
        {
            EnterLobby();
        }

        // Unsubscribe from events
        private void OnDestroy()
        {
            shotGrabGame.OnShotGrabbed -= HandleShotGrabbed;
            skillbarGame.OnSkillbarFinished -= HandleSkillbarFinished;
            lobby.OnPlayPressed -= HandlePlayPressed;
        }

        // ========================= LOBBY STATE =========================

        // Initializes the lobby state
        private void EnterLobby()
        {
            currentState = GameState.Lobby;
            currentScore = 0;

            lobby.Show();

            shotGrabGame.gameObject.SetActive(false);
            skillbarGame.gameObject.SetActive(false);
        }

        // Called when the player presses Play
        private void HandlePlayPressed()
        {
            if (currentState != GameState.Lobby)
                return;

            lobby.Hide();
            EnterShotGrab();
        }

        // ========================= SHOT GRAB STATE =========================

        // Starts the ShotGrab minigame
        private void EnterShotGrab()
        {
            currentState = GameState.ShotGrab;

            lobby.Hide();

            shotGrabGame.gameObject.SetActive(true);
            skillbarGame.gameObject.SetActive(false);

            shotGrabGame.StartGame();
        }

        // Called when a shot is successfully grabbed
        private void HandleShotGrabbed()
        {
            if (currentState != GameState.ShotGrab)
                return;

            StartCoroutine(TransitionToSkillbar());
        }

        // ========================= TRANSITION STATE =========================

        // Short delay before switching to the Skillbar minigame
        private IEnumerator TransitionToSkillbar()
        {
            currentState = GameState.Transition;

            shotGrabGame.StopGame();
            yield return new WaitForSeconds(delayBeforeSkillbar);

            EnterSkillbar();
        }

        // ========================= SKILLBAR STATE =========================

        // Starts the Skillbar minigame
        private void EnterSkillbar()
        {
            currentState = GameState.Skillbar;

            shotGrabGame.gameObject.SetActive(false);
            skillbarGame.gameObject.SetActive(true);

            skillbarGame.StartGame(currentScore);
        }

        // Called when the Skillbar minigame ends
        private void HandleSkillbarFinished(SkillbarResult result)
        {
            ApplySkillbarResult(result);
            EnterShotGrab();
        }

        // Applies score changes based on the Skillbar result
        private void ApplySkillbarResult(SkillbarResult result)
        {
            switch (result)
            {
                case SkillbarResult.Perfect:
                    currentScore += 2;
                    break;

                case SkillbarResult.Normal:
                    currentScore += 1;
                    break;

                case SkillbarResult.Fail:
                    currentScore = Mathf.Max(0, currentScore - 1);
                    break;
            }

            Debug.Log($"Current score: {currentScore}");
        }
    }
}
