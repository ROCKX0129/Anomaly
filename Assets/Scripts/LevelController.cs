using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelController : MonoBehaviour
{
    public TMP_Text levelCompleteText;         
    public GameObject targetObject;        
    public float delayBeforeNextLevel = 3f;

    private bool levelComplete = false;

    void Start()
    {
        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!levelComplete && targetObject == null)
        {
            levelComplete = true;
            StartCoroutine(LevelCompleteRoutine());
        }
    }

    IEnumerator LevelCompleteRoutine()
    {
        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(true);

        yield return new WaitForSeconds(delayBeforeNextLevel);

 
        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level1")
            SceneManager.LoadScene("Level2");
        else
            SceneManager.LoadScene("MainMenu"); 
    }
}

