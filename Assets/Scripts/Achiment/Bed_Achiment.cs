using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Achiment : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnDestroy()
    {
        Event.AchimBedTriger();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
