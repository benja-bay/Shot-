using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Gameplay.Minigames.Skillbar
{
    public class SkillbarGame : MonoBehaviour
    {
        public event Action<SkillbarResult> OnSkillbarFinished;

        [SerializeField] private SkillbarSelector selector;
        [SerializeField] private SkillbarEvaluator evaluator;

        private bool isActive;

        public void StartGame(int playerScore)
        {
            gameObject.SetActive(true);
            isActive = true;

            selector.Setup(playerScore);
            evaluator.SetupPerfectZone(playerScore);
            selector.StartMoving();
        }

        private void Update()
        {
            if (!isActive) return;

            if (Mouse.current.leftButton.wasPressedThisFrame ||
                (Touchscreen.current != null &&
                 Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
            {
                FinishSkillbar();
            }
        }

        private void FinishSkillbar()
        {
            isActive = false;
            selector.StopMoving();

            SkillbarResult result = evaluator.Evaluate(selector.CurrentY);
            OnSkillbarFinished?.Invoke(result);
        }
    }
}