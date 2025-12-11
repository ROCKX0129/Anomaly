using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Achim : MonoBehaviour
{
    private void OnDestroy()
    {
        Event.AchimTruckTriger();
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
