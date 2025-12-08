using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    private string pauseMenuScene;

    public void OpenPauseMenu()
    {
        SceneManager.LoadScene(3);
    }


}
