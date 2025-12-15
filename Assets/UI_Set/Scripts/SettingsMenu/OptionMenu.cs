using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class OptionMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject optionMenuUI;
    public Slider _masterSlider;
    public Slider _sfxSlider;
    public Toggle _subtitlesToggle;

    public GameObject _confirmPopup;

    public bool isSettingsScene = false;

    private GameSettings pendingSettings = new GameSettings();
    private GameSettings currentSettings = GameSettings.Instance;

    private bool hasUnsavedChanges = false;

    private GameObject pauseMenuUI;

    public void SetPauseMenu(GameObject pauseMenu)
    {
        pauseMenuUI = pauseMenu;
    }

    private void Start()
    {
        LoadSettingsToUI();

        if (!isSettingsScene)
        {
            optionMenuUI.SetActive(false);
        }
        else
        {
            optionMenuUI.SetActive(true);
        }

            
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
        optionMenuUI.SetActive(false);

        if(pauseMenuUI != null)
            pauseMenuUI.SetActive(true);
    }

    public void OnBackPressedMain()
    {
        SceneManager.LoadScene(0);
    }



    public void OpenSettings()
    {
        LoadSettingsToUI();
        optionMenuUI.SetActive(true);
    }



}
