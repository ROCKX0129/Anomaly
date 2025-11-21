using UnityEngine;
using UnityEngine.UI; // IMPORTANT: Need this namespace for the Text component
using System; // Needed for TimeSpan
using TMPro;


public class TimerDisplay : MonoBehaviour
{

    public TextMeshProUGUI timerText;

    private float elapsedTime;

    private bool isRunning = false;

    void Start()
    {
        elapsedTime = 600.0f;

        // Start the timer when the game begins
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime -= Time.deltaTime;

            // Update the UI display
            UpdateTimerDisplay(elapsedTime);

            timerText.text = elapsedTime.ToString(format:"0");

            if (elapsedTime <= 0 && isRunning)
            {
                isRunning  = false;
            }


        }
    }

    /// <summary>
    /// Starts or resumes the timer.
    /// </summary>
    public void StartTimer()
    {
        isRunning = true;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer()
    {
        isRunning = false;
    }

    /// <summary>
    /// Resets the timer to zero.
    /// </summary>
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay(0f); // Immediately update the display to show 00:00.00
    }

    /// <summary>
    /// Formats the time in seconds into a readable MM:SS.ms string and updates the Text component.
    /// </summary>
    /// <param name="timeInSeconds">The total elapsed time in seconds.</param>
    private void UpdateTimerDisplay(float timeInSeconds)
    {
        // Use TimeSpan to easily format time into minutes, seconds, and milliseconds
        TimeSpan time = TimeSpan.FromSeconds(timeInSeconds);

        // Format: MM:SS.ms (e.g., 05:30.15)
        string timeString = string.Format("{0:00}:{1:00}.{2:00}",
            time.Minutes,
            time.Seconds,
            time.Milliseconds / 10); // Divide by 10 to get two digits for milliseconds

        timerText.text = timeString;
    }
}