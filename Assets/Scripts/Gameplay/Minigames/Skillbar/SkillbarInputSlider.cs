using UnityEngine;
using UnityEngine.UI;
using System;

namespace Gameplay.Minigames.Skillbar
{
    public class SkillbarInputSlider : MonoBehaviour
    {
        public event Action OnSliderCompleted;

        [Header("References")]
        [SerializeField] private Slider slider;

        [Header("Settings")]
        [Range(0.7f, 1f)]
        [SerializeField] private float triggerThreshold = 0.95f;

        private bool isActive;

        private void Awake()
        {
            slider.onValueChanged.AddListener(OnValueChanged);
            slider.gameObject.SetActive(false);
        }

        public void Activate()
        {
            slider.value = 0f;
            isActive = true;
            slider.gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            isActive = false;
            slider.gameObject.SetActive(false);
        }

        private void OnValueChanged(float value)
        {
            if (!isActive) return;

            if (value >= triggerThreshold)
            {
                isActive = false;
                OnSliderCompleted?.Invoke();
            }
        }
    }
}

