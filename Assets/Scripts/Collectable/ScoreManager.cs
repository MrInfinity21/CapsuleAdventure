using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Score Stats")]
    [SerializeField] private int _currentScore = 0;
    

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    

    [Header("Events")]
    public UnityEvent<int> OnScoreChanged;
    

    public int GetScore() => _currentScore;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        UpdateScoreUI();
        FindScoreUI();
        
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindScoreUI();
        UpdateScoreUI();
    }

    private void FindScoreUI()
    {
        if (_scoreText == null)
        {
            GameObject scoreObj = GameObject.FindWithTag("ScoreText");
            if (scoreObj != null)
            {
                _scoreText = scoreObj.GetComponent<TextMeshProUGUI>();
            }
        }
    }


    public void AddScore(int points)
    {
        _currentScore += points;
        UpdateScoreUI();
        OnScoreChanged?.Invoke(_currentScore);
    }

    

    private void UpdateScoreUI()
    {
        if(_scoreText != null)
        {
            _scoreText?.SetText("Score: " + _currentScore);
        }
        
            
    }

    

}
