using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    [Header("UI")]
    public Slider _masterSlider;
    public Slider _sfxSlider;
    public Toggle _subtitlesToggle;

    public GameObject _confirmPopup;

    private string _backPauseMenu;

    private GameSettings pendingSettings = new GameSettings();
    private GameSettings currentSettings = new GameSettings();

    private bool hasUnsavedChanges = false;

    private void Start()
    {
        LoadSettingsToUI();
    }

    void LoadSettingsToUI()
    {
        _masterSlider.value = currentSettings._masterVolume;
        _sfxSlider.value = currentSettings._sfxVolume;
        _subtitlesToggle.isOn = currentSettings._subtitlesOn;

        pendingSettings._masterVolume = currentSettings._masterVolume;
        pendingSettings._sfxVolume = currentSettings._sfxVolume;
        pendingSettings._subtitlesOn = currentSettings._subtitlesOn;

    }

    public void OnMasterChanged(float value)
    {
        pendingSettings._masterVolume = value;
        hasUnsavedChanges = true;
    }

    public void OnSFXChanged(float value)
    {
        pendingSettings._sfxVolume = value;
        hasUnsavedChanges = true;
    }

    public void OnSubtitlesChanged(bool value)
    {
        pendingSettings._subtitlesOn = value;
        hasUnsavedChanges = true;
    }

    public void ApplyChanges()
    {
        _confirmPopup.SetActive(true);
    }

    public void ConfirmApplyYes()
    {
        currentSettings._masterVolume = pendingSettings._masterVolume;
        currentSettings._sfxVolume = pendingSettings._sfxVolume;
        currentSettings._subtitlesOn = pendingSettings._subtitlesOn;

        hasUnsavedChanges = false;
        _confirmPopup.SetActive(false);
    }

    public void ConfirmApplyNo()
    {
        _confirmPopup.SetActive(false);
    }

    public void OnBackPressed()
    {
        if (hasUnsavedChanges)
        {
            _confirmPopup.SetActive(true);
        }
        else
        {
            ReturnToPauseMenu();
        }
    }

    private void ReturnToPauseMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
