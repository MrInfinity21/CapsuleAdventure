using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverClick : MonoBehaviour
{

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.touchCount > 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
