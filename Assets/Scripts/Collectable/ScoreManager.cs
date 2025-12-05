using UnityEngine;
using UnityEngine.Events;
using TMPro;
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
        }
    }

    private void Start()
    {
        UpdateScoreUI();
        
    }

    public void AddScore(int points)
    {
        _currentScore += points;
        UpdateScoreUI();
        OnScoreChanged?.Invoke(_currentScore);
    }

    

    private void UpdateScoreUI()
    {
        if (_scoreText != null) 
            _scoreText.text = "Score: " + _currentScore;
    }

    

}
