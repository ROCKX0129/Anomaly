using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple_Achiment : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnDestroy()
    {
        Event.AchimAppleTriger();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
