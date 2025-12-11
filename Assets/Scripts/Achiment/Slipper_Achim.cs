using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper_Achim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
     void OnDestroy()
    {
        Event.AchimSlipperTriger();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
