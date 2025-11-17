using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance; // Singleton

    public GameObject pauseMenu;  // UI Panel (the PauseMenu object)
    [HideInInspector] public bool isPaused = false;

    void Awake()
    {
        // Singleton confirmation
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;   // Freeze game
        isPaused = true;

        // Show cursor and remove the locking
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;   // Unfreeze game
        isPaused = false;

        // Hide the cursor and lock in the game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnContinuePressed()
    {
        ResumeGame();
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }

    public void OnSettingsPressed()
    {
        // Open settings
        Debug.Log("Settings will be added later");
    }
}
