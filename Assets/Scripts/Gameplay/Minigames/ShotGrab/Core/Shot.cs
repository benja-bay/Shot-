using UnityEngine;

namespace Gameplay.Minigames.ShotGrab.Core
{
    [RequireComponent(typeof(Collider2D))]
    public class Shot : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float maxLifetime = 6f;

        private float speed;
        private Vector2 direction;
        public int LaneIndex { get; private set; }

        private float lifeTimer;

        public void Init(float speed, int laneIndex, Vector2 direction)
        {
            this.speed = speed;
            LaneIndex = laneIndex;
            this.direction = direction.normalized;
            lifeTimer = 0f;
        }

        private void Update()
        {
            transform.Translate(direction * speed * Time.deltaTime);

            lifeTimer += Time.deltaTime;
            if (lifeTimer >= maxLifetime)
            {
                Destroy(gameObject);
            }
        }

        public void Consume()
        {
            Destroy(gameObject);
        }
    }
}