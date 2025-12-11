using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Achivm : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Event.AchimTimeTriger();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
