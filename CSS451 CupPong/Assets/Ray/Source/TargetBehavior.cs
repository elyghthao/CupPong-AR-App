using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    MainController mainController;
    Vector3 distance;
    void Start()
    {
        mainController = FindObjectOfType<MainController>();
    }

    
    void Update()
    {
        if (mainController.ball != null) {
            distance = this.transform.position - mainController.ball.transform.position;
            if (distance.magnitude <= this.transform.localScale.x) {
                mainController.Score();
                // deletes the cup
                // Destroy(this.transform.parent);
                Destroy(this.gameObject);
            }
        }
    }
}
