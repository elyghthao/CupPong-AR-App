using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    public bool holdingBall = true;
    Vector3 startPosition;
    Vector3 endPosition;
    float timeElapsed;
    float touchTimeStart, touchTimeEnd, timeInterval;
    public GameObject camera;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        // disable gravity until clicked
        rb.useGravity = false;
    }

    
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && holdingBall) {
            touchTimeStart = Time.time;
            startPosition = Input.GetTouch(0).position;
        }

        // release ball when mouse let go
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && holdingBall) {
            touchTimeEnd = Time.time;
            timeInterval = touchTimeEnd - touchTimeStart;
            endPosition = Input.GetTouch(0).position;
            holdingBall = false;
            rb.useGravity = true;


            Vector3 force = endPosition - startPosition;
            force.z = force.y;
            rb.AddForce(camera.transform.right * force.x * 15f, ForceMode.Force);
            rb.AddForce(camera.transform.up * force.y * 15f, ForceMode.Force);
            rb.AddForce(camera.transform.forward * force.z * 15f, ForceMode.Force);





            // Vector3 direction = camera.transform.forward;
            // direction *= (endPosition-startPosition).y;

            // rb.AddForce(force *15f, ForceMode.Force);

        }
        if (!holdingBall) Destroy(this.gameObject, 5.0f);
    }
}
