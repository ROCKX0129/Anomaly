using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToothBrush_Achivm : MonoBehaviour
{
    private void OnDestroy()
    {
        Event.AchimToothBrushTriger();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
