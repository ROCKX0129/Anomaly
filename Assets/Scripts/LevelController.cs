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

    private int AnomalyNum = 1;

    private bool levelComplete = false;

    public string targetLayerName = "Interactable";

    private int targetLayer;





    void CountObjectsInLayer()
    {
        int count = 0;

        var allObjects = FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            if (obj.layer == targetLayer)
                count++;
        }
        AnomalyNum = count;

        //Debug.Log("Layer " + targetLayerName + " The AnomalyLeft£º" + AnomalyNum);
    }

    void Start()
    {
        if (levelCompleteText != null)
            levelCompleteText.gameObject.SetActive(false);

        targetLayer = LayerMask.NameToLayer(targetLayerName);

    }

    void Update()
    {
        if (levelComplete == false)
        {

            if (AnomalyNum == 0)
            {
                Debug.Log("it over");
                levelComplete = true;
                StartCoroutine(LevelCompleteRoutine());
            }
        }
        CountObjectsInLayer();
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

