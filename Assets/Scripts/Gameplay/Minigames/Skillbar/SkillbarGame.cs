using UnityEngine;
using System;

namespace Gameplay.Minigames.Skillbar
{
    public class SkillbarGame : MonoBehaviour
    {
        public event Action<SkillbarResult> OnSkillbarFinished;

        [Header("References")]
        [SerializeField] private SkillbarSelector selector;
        [SerializeField] private SkillbarEvaluator evaluator;
        [SerializeField] private SkillbarInputSlider inputSlider;

        private bool isActive;

        private void Awake()
        {
            inputSlider.OnSliderCompleted += FinishSkillbar;
        }

        public void StartGame(int playerScore)
        {
            gameObject.SetActive(true);
            isActive = true;

            selector.Setup(playerScore);
            evaluator.SetupPerfectZone(playerScore);

            selector.StartMoving();
            inputSlider.Activate();
        }

        private void FinishSkillbar()
        {
            if (!isActive) return;

            isActive = false;

            selector.StopMoving();
            inputSlider.Deactivate();

            SkillbarResult result = evaluator.Evaluate(selector.CurrentY);
            OnSkillbarFinished?.Invoke(result);
        }
    }
}