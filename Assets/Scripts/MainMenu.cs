using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
    }

    void StartGame()
    {
        
        SceneManager.LoadScene("Level1");
    }

    void QuitGame()
    {
        Debug.Log("Quit Game"); 
        Application.Quit();      
    }
}

