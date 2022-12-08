using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 spawnPoint = new Vector3 (0f, -1f, 0f);
    void Start()
    {
        
    }

    
    void Update()
    {
        if (ball == null) {
            ball = Instantiate<GameObject>(Resources.Load("Prefabs/Pong") as GameObject, spawnPoint, Quaternion.identity);
        }
    }
}
