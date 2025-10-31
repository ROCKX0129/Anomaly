using UnityEngine;
using UnityEngine.UI; // IMPORTANT: Need this namespace for the Text component
using System; // Needed for TimeSpan

/// <summary>
/// A simple script to manage a count-up timer and display it on a UI Text component.
/// </summary>
public class TimerDisplay : MonoBehaviour
{
    // Drag your UI Text component here in the Inspector
    [Tooltip("Assign the Text UI component that will display the time.")]
    public Text timerText;

    // Stores the total time elapsed since the timer started
    private float elapsedTime;

    // Flag to control if the timer is actively running
    private bool isRunning = false;

    void Start()
    {
        // Check if the Text component is assigned before starting
        if (timerText == null)
        {
            Debug.LogError("Timer Text component is not assigned! Please assign it in the Inspector.");
            enabled = false; // Disable the script if the setup is incomplete
            return;
        }

        // Start the timer when the game begins
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            // Add the time passed since the last frame
            elapsedTime += Time.deltaTime;

            // Update the UI display
            UpdateTimerDisplay(elapsedTime);
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