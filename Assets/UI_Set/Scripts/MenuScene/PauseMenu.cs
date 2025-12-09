using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [Header("UI")]
    public GameObject pauseMenuUI;
    public OptionMenu optionMenuUI;

    [Header("Confirmation Panels")]
    public GameObject _returnToMainConfirmPanel;
    public GameObject _exitGameConfirmPanel;


    private void Start()
    {
        optionMenuUI.SetPauseMenu(pauseMenuUI);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        pauseMenuUI.SetActive(false);
    }

    public void SettingsMenu()
    {
        pauseMenuUI.SetActive(false);
        optionMenuUI.OpenSettings();
     
    }

  
    public void ReturnToMainMenu()
    {
        _returnToMainConfirmPanel.SetActive(true);
    }

    public void ConfirmReturnYes()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void ConfirmReturnNo()
    {
        _returnToMainConfirmPanel.SetActive(false);
    }

    
    public void ExitGame()
    {
        _exitGameConfirmPanel.SetActive(true);
    }
    public void ConfirmExitYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void ConfirmExitNo()
    {
        _exitGameConfirmPanel.SetActive(false);
    }
}
