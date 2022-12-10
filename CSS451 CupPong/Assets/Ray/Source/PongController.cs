using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongController : MonoBehaviour
{
    public float throwForce = 100f;
    float throwDirectionX = 0.17f;
    float throwDirectionY = 0.67f;
    Vector3 ballCameraOffset = new Vector3(0f, -1.4f, 2f);
    Vector3 startPosition;
    Vector3 direction;
    float startTime, endTime, duration;
    bool directionChosen = false;
    bool throwStarted = false;
    [SerializeField]
    GameObject ARCam;
    
    [SerializeField]
    // ARSessionOrigin sessionOrigin;
    
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
  
    }

    
    void Update()
    {
        
    }
}
