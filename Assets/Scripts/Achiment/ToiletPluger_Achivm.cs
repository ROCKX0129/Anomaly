using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletPluger_Achivm : MonoBehaviour
{
    private void OnDestroy()
    {
        Event.AchimToiletPlugerTriger();
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
