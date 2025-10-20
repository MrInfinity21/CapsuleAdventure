using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Score Stats")]
    [SerializeField] private int _currentScore = 0;
    [SerializeField] private int _itemsCollected = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _itemsText;

    [Header("Events")]
    public UnityEvent<int> OnScoreChanged;
    public UnityEvent<int> OnItemsCollected;

    public int GetScore() => _currentScore;
    public int GetItemsCollected() => _itemsCollected;

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
        UpdateItemsUI();
    }

    public void AddScore(int points)
    {
        _currentScore += points;
        UpdateScoreUI();
        OnScoreChanged?.Invoke(_currentScore);
    }

    public void AddItem()
    {
        _itemsCollected++;
        UpdateItemsUI();
        OnItemsCollected?.Invoke(_itemsCollected);
    }

    private void UpdateScoreUI()
    {
        if (_scoreText != null) 
            _scoreText.text = "Score: " + _currentScore;
    }

    private void UpdateItemsUI()
    {
        if (_itemsText != null)
            _itemsText.text = "Items collected: " + _itemsCollected;
    }

}
