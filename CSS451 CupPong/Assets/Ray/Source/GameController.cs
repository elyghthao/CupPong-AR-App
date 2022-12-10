using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    private Vector3 spawnPoint = new Vector3 (0f, -1f, 0f);
    public int cupsRemaining = 9;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (ball == null) {
            RespawnBall();
        }
    }

    public void Score() {
        cupsRemaining--;
        Destroy(ball);
        RespawnBall();
    }

    void RespawnBall() {
        ball = Instantiate<GameObject>(Resources.Load("Prefabs/Pong") as GameObject, spawnPoint, Quaternion.identity);
    }
}
