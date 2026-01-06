using Gameplay.Minigames.ShotGrab.Player;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Minigames.ShotGrab.Input
{
    public class LaneInputController : MonoBehaviour
    {
        [SerializeField] private HandController hand;
        [SerializeField] private float dragSensitivity = 0.01f;

        private Vector2 lastPosition;
        private bool isDragging;

        private void Update()
        {
            HandleTouch();
            HandleMouse();
        }

        private void HandleTouch()
        {
            if (Touchscreen.current == null) return;

            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.isPressed)
            {
                Vector2 pos = touch.position.ReadValue();
                ProcessDrag(pos);
            }
            else
            {
                isDragging = false;
            }
        }

        private void HandleMouse()
        {
            if (!Mouse.current.leftButton.isPressed)
            {
                isDragging = false;
                return;
            }

            Vector2 pos = Mouse.current.position.ReadValue();
            ProcessDrag(pos);
        }

        private void ProcessDrag(Vector2 pos)
        {
            if (!isDragging)
            {
                lastPosition = pos;
                isDragging = true;
            }

            float deltaY = (pos.y - lastPosition.y) * dragSensitivity;
            hand.MoveVertical(deltaY);
            lastPosition = pos;
        }
    }
}
