using Core;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class MainScreenPresenter : MonoBehaviour {
        [SerializeField] private Button resetButton;
        [SerializeField] private Button moveCharacterButton;
        [SerializeField] private Button applySettingsButton;
        [SerializeField] private CharacterMover character;
        [SerializeField] private PlaneDeformation planeDeformation;

        private void OnEnable() {
            resetButton.onClick.AddListener(OnResetButtonClick);
            moveCharacterButton.onClick.AddListener(OnMoveButtonClick);
            applySettingsButton.onClick.AddListener(OnApplyButtonClick);
        }

        private void OnResetButtonClick() {
            planeDeformation.ResetPlane();
        }
        
        private void OnMoveButtonClick() {
            character.Move();
        }
        
        private void OnApplyButtonClick() {
            planeDeformation.ConfigureSettings();
        }

        private void OnDisable() {
            resetButton.onClick.RemoveListener(OnResetButtonClick);
            moveCharacterButton.onClick.RemoveListener(OnMoveButtonClick);
            applySettingsButton.onClick.RemoveListener(OnApplyButtonClick);
        }
    }
}