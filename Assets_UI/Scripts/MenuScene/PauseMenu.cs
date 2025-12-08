using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [Header("Confirmation Panels")]
    public GameObject _returnToMainConfirmPanel;
    public GameObject _exitGameConfirmPanel;


    public void ResumeGame()
    {
        SceneManager.LoadScene(4);
    }

    public void ReturnToMainMenu()
    {
        _returnToMainConfirmPanel.SetActive(true);
    }

    public void ConfirmReturnYes()
    {
        SceneManager.LoadScene(0);
    }

    public void ConfirmReturnNo()
    {
        _returnToMainConfirmPanel.SetActive(false);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene(3);
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
