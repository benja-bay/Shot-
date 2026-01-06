using UnityEngine;

namespace Gameplay.Minigames.Skillbar
{
    public enum SkillbarResult
    {
        Fail,
        Normal,
        Perfect
    }

    public class SkillbarEvaluator : MonoBehaviour
    {
        [Header("Perfect Zone")]
        [SerializeField] private RectTransform perfectZone;

        public SkillbarResult Evaluate(float selectorY)
        {
            float min = perfectZone.anchoredPosition.y - perfectZone.rect.height / 2f;
            float max = perfectZone.anchoredPosition.y + perfectZone.rect.height / 2f;

            if (selectorY >= min && selectorY <= max)
                return SkillbarResult.Perfect;

            return SkillbarResult.Normal;
        }

        public void SetupPerfectZone(int playerScore)
        {
            float width = Mathf.Lerp(120f, 40f, playerScore / 100f);
            perfectZone.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, width);
        }
    }
}