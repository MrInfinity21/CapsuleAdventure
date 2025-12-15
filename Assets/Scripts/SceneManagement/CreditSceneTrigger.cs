using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneTrigger : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
