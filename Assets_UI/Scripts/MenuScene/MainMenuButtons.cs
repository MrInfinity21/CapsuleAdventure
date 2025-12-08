using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuButtons : MonoBehaviour
{
    public GameObject _exitConfirmPanel;

    public void StartNewGame()
    {
        SceneManager.LoadScene(4);
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        _exitConfirmPanel.SetActive(true);
    }
  

    public void ConfirmYes()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ConfirmNo()
    {
        _exitConfirmPanel.SetActive(false);
    }
}
