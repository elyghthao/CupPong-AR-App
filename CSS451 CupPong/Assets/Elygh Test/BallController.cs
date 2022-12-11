using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject mainCam;
    public bool holdingBall;
    public GameObject curBall;
    public Vector3 ballPosition;
    public SecondCamera camScript;
    // Start is called before the first frame update
    void Start()
    {
        holdingBall = true;
        curBall = null;
    }

    // Update is called once per frame
    void Update()
    {
        
        ballPosition = mainCam.transform.position;
        if(curBall == null){
            RespawnBall();
        }else {
            if(curBall.GetComponent<BallBehavior>().holdingBall){
                ballPosition += (mainCam.transform.forward * 0.5f);
                ballPosition += (mainCam.transform.up * -0.25f);
                curBall.transform.position = ballPosition;
            }
            
        }
    }

    void RespawnBall() {
        curBall = Instantiate<GameObject>(ballPrefab, ballPosition, Quaternion.identity);
        curBall.GetComponent<BallBehavior>().camera = mainCam;
        camScript.target = curBall;
        camScript.ballScript = curBall.GetComponent<BallBehavior>();
        curBall.GetComponent<BallBehavior>().placementScript = this.GetComponent<ARPlacement>();
    }
}
