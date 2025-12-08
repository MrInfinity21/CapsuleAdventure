using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class ObjectiveDisplay : MonoBehaviour
{
    [Header("UI Refer")]
    [SerializeField] private CanvasGroup _objectivePanel;

    [Header("Animation Settings")]
    [SerializeField] private float _fadeDuration = 0.5f;
    [SerializeField] private float _displayDuration = 2f;

    private bool _isVisible = false;
    private Coroutine _currentFadeRoutine;


    void Start()
    {
        if (_objectivePanel != null)
        {
            _objectivePanel.alpha = 0f;
            _objectivePanel.gameObject.SetActive(false);
        }     
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ShowObjective();
        }
    }

    public void ShowObjective()
    {
    

        if (_currentFadeRoutine != null)
             StopCoroutine(_currentFadeRoutine);

            _currentFadeRoutine = StartCoroutine(ShowAndHideRoutine());
        
    }

    private IEnumerator ShowAndHideRoutine()
    {
        _objectivePanel.gameObject.SetActive(true);

        yield return StartCoroutine(FadeCanvasGroup(_objectivePanel, 0f, 1f));

        float timer = 0f;
        while (timer < _displayDuration)
        {
            timer += Time.unscaledDeltaTime;
            yield return null;
        }

        yield return StartCoroutine(FadeCanvasGroup(_objectivePanel, 1f, 0f));

        _objectivePanel.gameObject.SetActive(false);
        _isVisible = false;
        _currentFadeRoutine = null;
    }

    
    private IEnumerator FadeCanvasGroup(CanvasGroup canvasGroup, float start, float end)
    {
        float elapsed = 0f;

        while (elapsed < _fadeDuration)
        {
            elapsed += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / _fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }
}
