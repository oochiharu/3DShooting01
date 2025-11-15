using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Handles the BOM weapon button, including cooldown management and the enemy wipe effect.
/// </summary>
public class BomWeaponController : MonoBehaviour
{
    /// <summary>
    /// Reference to the UI button that triggers the BOM effect.
    /// </summary>
    [SerializeField] private Button _bomButton;

    /// <summary>
    /// Label that displays the button text and the remaining cooldown.
    /// </summary>
    [SerializeField] private TextMeshProUGUI _bomLabel;

    /// <summary>
    /// Number of seconds that must pass before the button can be pressed again.
    /// </summary>
    [SerializeField] private float _cooldownSeconds = 15f;

    /// <summary>
    /// Tracks how much time is left before the button becomes active again.
    /// </summary>
    private float _cooldownTimer = 0f;

    /// <summary>
    /// Keeps track of whether the BOM is currently recharging.
    /// </summary>
    private bool _isCoolingDown = false;

    /// <summary>
    /// Initializes the button listener and ensures the visual state matches the cooldown.
    /// </summary>
    private void Start()
    {
        // Register the click event so pressing the button triggers the BOM effect logic.
        _bomButton.onClick.AddListener(OnBomButtonPressed);
        UpdateButtonState();
    }

    /// <summary>
    /// Updates the cooldown timer every frame and refreshes the display when necessary.
    /// </summary>
    private void Update()
    {
        if (!_isCoolingDown)
        {
            return;
        }

        // Reduce the timer based on how much time passed since the last frame.
        _cooldownTimer -= Time.deltaTime;
        if (_cooldownTimer <= 0f)
        {
            // Cooldown complete, so re-enable the button.
            _cooldownTimer = 0f;
            _isCoolingDown = false;
            UpdateButtonState();
        }
        else
        {
            // While cooling down keep the countdown text updated.
            UpdateCooldownLabel();
        }
    }

    /// <summary>
    /// Performs the BOM action by destroying all current enemies and starting the cooldown.
    /// </summary>
    private void OnBomButtonPressed()
    {
        // Search for every active enemy and remove them from the scene.
        EnemyBase[] enemies = FindObjectsOfType<EnemyBase>();
        foreach (EnemyBase enemy in enemies)
        {
            Destroy(enemy.gameObject);
        }

        // Begin the cooldown so the player cannot spam the ability.
        _isCoolingDown = true;
        _cooldownTimer = _cooldownSeconds;
        UpdateButtonState();
    }

    /// <summary>
    /// Applies the correct interactable state and text based on whether the BOM is ready.
    /// </summary>
    private void UpdateButtonState()
    {
        bool interactable = !_isCoolingDown;
        _bomButton.interactable = interactable;

        if (interactable)
        {
            // When ready, simply show the weapon name.
            _bomLabel.text = "BOM";
        }
        else
        {
            // When not ready, show the remaining countdown.
            UpdateCooldownLabel();
        }
    }

    /// <summary>
    /// Updates the label text with the remaining cooldown rounded up to whole seconds.
    /// </summary>
    private void UpdateCooldownLabel()
    {
        int remainingSeconds = Mathf.CeilToInt(_cooldownTimer);
        _bomLabel.text = $"BOM ({remainingSeconds})";
    }
}
