using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondCamera : MonoBehaviour
{
    
    public bool onMainCamera;
    public Toggle toggle;
    public GameObject target;
    public GameObject secondCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onMainCamera = toggle.isOn;

        if(onMainCamera){//show main camera
            secondCamera.GetComponent<Camera>().enabled = false;
        }else {//show secondary camera
            if(target != null){
                secondCamera.GetComponent<Camera>().enabled = true;
            }
            
        }

        if(target!=null){
            this.transform.position = target.transform.position;
        }
    }
}
