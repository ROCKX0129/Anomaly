using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushRoom_Achim : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDestroy()
    {
        Event.AchimMushroomTriger();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
