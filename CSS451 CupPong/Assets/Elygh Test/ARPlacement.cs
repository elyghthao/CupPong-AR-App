using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

public class ARPlacement : MonoBehaviour
{
    //got code from https://www.youtube.com/watch?v=KqzlGApWPEA&t=375s
    public GameObject arObjectToSpawn;
    public GameObject placementindicator;
    private GameObject spawnedObject;


    private Pose PlacementPose;
    private ARRaycastManager aRRaycastManager;
    private bool placementposeIsValid;
    public SecondCamera camScript;

    public SceneNode TheRoot;


    
    public bool test;

    public bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        aRRaycastManager = FindObjectOfType<ARRaycastManager>();
        test = false;
        firstTime = true;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if((spawnedObject == null && placementposeIsValid && Input.touchCount>0 && Input.GetTouch(0).phase == TouchPhase.Began) || test){
            test = false;
            ARPlaceObject();
            
        }
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        UpdateHierarchy();
    }


    void UpdatePlacementIndicator(){

        if((spawnedObject == null && placementposeIsValid )){
            placementindicator.SetActive(true);
            placementindicator.transform.SetPositionAndRotation(PlacementPose.position, PlacementPose.rotation);
        }else {
            placementindicator.SetActive(false);
        }
    }

    void UpdatePlacementPose(){
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f,0.5f));
        var hits = new List<ARRaycastHit>();
        aRRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementposeIsValid = hits.Count > 0;
        if(placementposeIsValid){
            PlacementPose = hits[0].pose;
        }
    }

    void ARPlaceObject(){
        spawnedObject = Instantiate(arObjectToSpawn, PlacementPose.position, PlacementPose.rotation);
        // spawnedObject = Instantiate(arObjectToSpawn, new Vector3(0,0,5), PlacementPose.rotation);
        camScript.target = spawnedObject;
        if(spawnedObject.name == "Cube"){
            return;
        }


        

    }

    private void UpdateHierarchy() {
        if(spawnedObject == null){return;}
        Matrix4x4 i = Matrix4x4.identity;
        TheRoot = spawnedObject.GetComponent<SceneNode>();
        TheRoot.CompositeXform(ref i);

        // Matrix4x4 a = Matrix4x4.identity;
        // a.CompositeXform(ref i);


        // foreach(SceneNode a in list){
        //     a.CompositeXform(ref i);
        // }
        
        

        

        // FrontTip.localPosition = secondJoin.localPosition + FrontHeight * secondJoin.up;
        // FrontTip.localRotation = secondJoin.localRotation;
    }
}
