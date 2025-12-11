using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper_View : MonoBehaviour
{
    void OnEnable()
    {
        Event.Achim_Slipper += Achievenment;
    }

    void Start()
    {
        SetLayerRecursively(gameObject, 9);
    }

    void Achievenment()
    {
        StartCoroutine(VisibleChanged());
    }


    IEnumerator VisibleChanged()
    {
        SetLayerRecursively(gameObject, 10);

        yield return new WaitForSeconds(5);

        SetLayerRecursively(gameObject, 9);
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SetLayerRecursively(GameObject obj, int newLayer)
    {
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            SetLayerRecursively(child.gameObject, newLayer);
        }
    }
}
