using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core {
    public class DevSettingsPresenter : MonoBehaviour {
        [SerializeField] private PlaneDeformationData deformationData;
        [SerializeField] private Slider strengthSlider;
        [SerializeField] private Slider areaSlider;
        [SerializeField] private Slider smoothSlider;
        [SerializeField] private TMP_Text strengthText;
        [SerializeField] private TMP_Text areaText;
        [SerializeField] private TMP_Text smoothText;

        private void Awake() {
            ConfigureValues();
        }

        private void ConfigureValues() {
            strengthSlider.value = deformationData.strength;
            areaSlider.value = deformationData.area;
            smoothSlider.value = deformationData.smoothing;

            strengthText.text = $"Strength ({deformationData.strength.ToString("0.00",CultureInfo.InvariantCulture)}):";
            areaText.text = $"Area ({deformationData.area.ToString("0.00",CultureInfo.InvariantCulture)}):";
            smoothText.text = $"Smoothing ({deformationData.smoothing.ToString("0.00",CultureInfo.InvariantCulture)}):";

            strengthSlider.onValueChanged.AddListener(OnStrengthChanged);
            areaSlider.onValueChanged.AddListener(OnAreaChanged);
            smoothSlider.onValueChanged.AddListener(OnSmoothChanged);
        }

        private void OnStrengthChanged(float value) {
            deformationData.strength = value;
            strengthText.text = $"Strength ({value.ToString("0.00", CultureInfo.InvariantCulture)}):";
        }

        private void OnAreaChanged(float value) {
            deformationData.area = value;
            areaText.text = $"Area ({value.ToString("0.00",CultureInfo.InvariantCulture)}):";
        }

        private void OnSmoothChanged(float value) {
            deformationData.smoothing = value;
            smoothText.text = $"Smoothing ({value.ToString("0.00",CultureInfo.InvariantCulture)}):";
        }

        private void OnDisable() {
            strengthSlider.onValueChanged.RemoveListener(OnStrengthChanged);
            areaSlider.onValueChanged.RemoveListener(OnAreaChanged);
            smoothSlider.onValueChanged.RemoveListener(OnSmoothChanged);
        }
    }
}