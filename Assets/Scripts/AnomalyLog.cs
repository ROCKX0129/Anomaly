using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnomalyLog : MonoBehaviour
{
    public Image anomalyIcon;

    private bool isFound = false;

    // Call this method when the player finds an anomaly
    public void MarkAsFound()
    {
        if (isFound) return; // Does nothing if already found

        isFound = true;

        if (anomalyIcon != null)
        {
            anomalyIcon.color = Color.white; // change grey -> white
        }
    }

    public bool IsFound()
    {
        return isFound;
    }
}

