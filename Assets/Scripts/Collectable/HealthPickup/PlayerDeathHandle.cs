using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathHandle : MonoBehaviour
{

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private int gameOverSceneIndex = 6;

    private void Start()
    {
        if(playerHealth != null)
        {
            playerHealth.OnPlayerDeath += HandlePlayerDeath;
        }
    }

    private void OnDestroy()
    {
        if(playerHealth != null)
        {
            playerHealth.OnPlayerDeath -= HandlePlayerDeath;
        }
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("Player died. Loading Game Over Scene");
        SceneManager.LoadScene(6);
    }

}
