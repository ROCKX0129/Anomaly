using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGray_Achiment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnDestroy()
    {
        Event.AchimTheGrayTriger();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
