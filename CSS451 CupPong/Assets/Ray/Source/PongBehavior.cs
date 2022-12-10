using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBehavior : MonoBehaviour
{
    private Rigidbody rb;
    private bool holdingBall = true;
    Vector3 startPosition;
    Vector3 endPosition;
    float timeElapsed;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        // disable gravity until clicked
        rb.useGravity = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            startPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
        }
        // release ball when mouse let go
        if (Input.GetMouseButtonUp(0)) {
            holdingBall = false;
            endPosition = Camera.main.WorldToScreenPoint(Input.mousePosition);
            rb.useGravity = true;
            Vector3 force = endPosition - startPosition;
            force.z = force.y * 0.5f;
            rb.AddForce(force, ForceMode.Force);
        }
        if (!holdingBall) timeElapsed += Time.deltaTime;
        if (NotMoving()) {
            Debug.Log("Test");
            Destroy(this.gameObject);
        }
    }
    bool NotMoving() {
        return (timeElapsed > 1.0f && rb.velocity.magnitude == 0 && holdingBall == false);
    }
}
