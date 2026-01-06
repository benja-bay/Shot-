using System.Collections;
using UnityEngine;
using Gameplay.Minigames.ShotGrab;
using Gameplay.Minigames.ShotGrab.Core;
using Gameplay.Minigames.Skillbar;

namespace Gameplay.GameFlow
{
    public class GameFlowController : MonoBehaviour
    {
        private enum GameState
        {
            ShotGrab,
            Transition,
            Skillbar
        }

        [Header("Minigames")]
        [SerializeField] private ShotGrabGame shotGrabGame;
        [SerializeField] private SkillbarGame skillbarGame;

        [Header("Transition")]
        [SerializeField] private float delayBeforeSkillbar = 1.5f;

        private GameState currentState;
        private int currentScore;

        private void Awake()
        {
            shotGrabGame.OnShotGrabbed += HandleShotGrabbed;
            skillbarGame.OnSkillbarFinished += HandleSkillbarFinished;
        }

        private void Start()
        {
            EnterShotGrab();
        }

        private void OnDestroy()
        {
            shotGrabGame.OnShotGrabbed -= HandleShotGrabbed;
            skillbarGame.OnSkillbarFinished -= HandleSkillbarFinished;
        }

        private void EnterShotGrab()
        {
            currentState = GameState.ShotGrab;

            shotGrabGame.gameObject.SetActive(true);
            skillbarGame.gameObject.SetActive(false);

            shotGrabGame.StartGame();
        }

        private void HandleShotGrabbed()
        {
            if (currentState != GameState.ShotGrab)
                return;

            StartCoroutine(TransitionToSkillbar());
        }

        private IEnumerator TransitionToSkillbar()
        {
            currentState = GameState.Transition;

            shotGrabGame.StopGame();
            yield return new WaitForSeconds(delayBeforeSkillbar);

            EnterSkillbar();
        }

        private void EnterSkillbar()
        {
            currentState = GameState.Skillbar;

            shotGrabGame.gameObject.SetActive(false);
            skillbarGame.gameObject.SetActive(true);

            skillbarGame.StartGame(currentScore);
        }

        private void HandleSkillbarFinished(SkillbarResult result)
        {
            ApplySkillbarResult(result);
            EnterShotGrab();
        }

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

            Debug.Log($"Score actual: {currentScore}");
        }
    }
}
