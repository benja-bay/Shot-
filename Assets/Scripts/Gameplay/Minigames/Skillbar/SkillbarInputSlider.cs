using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

namespace Gameplay.Minigames.Skillbar
{
    public class SkillbarInputSlider : MonoBehaviour,
        IPointerDownHandler,
        IPointerUpHandler
    {
        public event Action OnSliderCompleted;

        [Header("References")]
        [SerializeField] private Slider slider;

        [Header("Completion")]
        [Range(0.7f, 1f)]
        [SerializeField] private float triggerThreshold = 0.95f;

        [Header("Return")]
        [SerializeField] private float returnSpeed = 0.6f;

        private bool isActive;
        private bool isDragging;

        private void Awake()
        {
            slider.gameObject.SetActive(false);
        }

        public void Activate()
        {
            slider.value = 0f;
            isActive = true;
            isDragging = false;
            slider.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            isActive = false;
            isDragging = false;
            slider.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!isActive) return;

            if (!isDragging && slider.value > 0f)
            {
                slider.value -= returnSpeed * Time.deltaTime;
                slider.value = Mathf.Max(slider.value, 0f);
            }

            if (slider.value >= triggerThreshold)
            {
                isActive = false;
                OnSliderCompleted?.Invoke();
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (!isActive) return;
            isDragging = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!isActive) return;
            isDragging = false;
        }
    }
}

