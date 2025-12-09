using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;
        isPaused = true;
    }



    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
        isPaused = false;
    }


}
