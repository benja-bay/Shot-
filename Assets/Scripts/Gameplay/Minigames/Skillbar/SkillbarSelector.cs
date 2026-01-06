using UnityEngine;

namespace Gameplay.Minigames.Skillbar
{
    public class SkillbarSelector : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private RectTransform bar;
        [SerializeField] private RectTransform selector;

        [Header("Speed")]
        [SerializeField] private float baseSpeed = 200f;
        [SerializeField] private float maxSpeed = 400f;

        private float speed;
        private float minY;
        private float maxY;
        private float direction = 1f;
        private bool isMoving;

        public float CurrentY => selector.anchoredPosition.y;

        public void Setup(int playerScore)
        {
            float t = Mathf.Clamp01(playerScore / 100f);
            speed = Mathf.Lerp(baseSpeed, maxSpeed, t);

            CalculateLimits();
        }

        private void CalculateLimits()
        {
            float barHalf = bar.rect.height * 0.5f;
            float selectorHalf = selector.rect.height * 0.5f;

            minY = -barHalf + selectorHalf;
            maxY = barHalf - selectorHalf;
        }

        public void StartMoving()
        {
            isMoving = true;
        }

        public void StopMoving()
        {
            isMoving = false;
        }

        private void Update()
        {
            if (!isMoving) return;

            Vector2 pos = selector.anchoredPosition;
            pos.y += direction * speed * Time.deltaTime;

            if (pos.y >= maxY)
            {
                pos.y = maxY;
                direction = -1f;
            }
            else if (pos.y <= minY)
            {
                pos.y = minY;
                direction = 1f;
            }

            selector.anchoredPosition = pos;
        }
    }
}