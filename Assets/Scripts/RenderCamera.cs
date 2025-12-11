using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCamera : MonoBehaviour
{

    public float rotateSpeed = 50f;
    public Vector3 rotationAxis = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Vector3.zero, rotationAxis, rotateSpeed * Time.deltaTime);
    }
}
