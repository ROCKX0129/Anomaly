using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button quitButton;

    private float elapsedTime;
    private bool isRunning = false;

    public float fadeDuration = 1.5f;

    private void OnEnable()
    {
        Event.AnomolyFound += TimeAdded;
    }

    private void OnDisable()
    {

    }

    void TimeAdded()
    {
        elapsedTime += 2.0f;
    }

    void Start()
    {
        elapsedTime = 20.0f;

        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartTimer();
    }

    void Update()
    {
        if (!isRunning) return;

        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0)
        {
            elapsedTime = 0;
            EndGame();
            return;
        }

        UpdateTimerDisplay(elapsedTime);
    }

    private void EndGame()
    {
        isRunning = false;
        UpdateTimerDisplay(0);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0f;

        StartCoroutine(FadeGameOver());
    }

    private IEnumerator FadeGameOver()
    {
        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);

        CanvasGroup textGroup = gameOverText.gameObject.AddComponent<CanvasGroup>();
        CanvasGroup retryGroup = retryButton.gameObject.AddComponent<CanvasGroup>();
        CanvasGroup quitGroup = quitButton.gameObject.AddComponent<CanvasGroup>();

        textGroup.alpha = 0;
        retryGroup.alpha = 0;
        quitGroup.alpha = 0;

        float t = 0;

        while (t < fadeDuration)
        {
            t += Time.unscaledDeltaTime;

            float alpha = t / fadeDuration;

            textGroup.alpha = alpha;
            retryGroup.alpha = alpha;
            quitGroup.alpha = alpha;

            yield return null;
        }

        textGroup.alpha = 1;
        retryGroup.alpha = 1;
        quitGroup.alpha = 1;
    }

    public void Retry()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);

        string timeString = string.Format("{0:00}:{1:00}.{2:00}",
            time.Minutes,
            time.Seconds,
            time.Milliseconds / 10);

        timerText.text = timeString;
    }
}
