using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [ExecuteInEditMode]
public class TheWorld : MonoBehaviour  {

    public SceneNode TheRoot;
    public Transform RootOrg;
    public SceneNode firstTable;
    public Transform firstJoin;
    public SceneNode secondTable;
    public Transform secondJoin;
    public SceneNode thirdTable;
    public Transform thirdJoin;

   

    string tableLevel;

    private void Start()
    {
        
    }

    private void Update()
    {
        //TheRoot.OrbitAroundWorldY(0.4f); // degree
        if ((Input.touchCount > 0) && (Input.GetTouch (0).phase == TouchPhase.Began)) {
            Ray raycast = Camera.main.ScreenPointToRay (Input.GetTouch (0).position);
            RaycastHit raycastHit;
            if (Physics.Raycast (raycast, out raycastHit)) {
                Debug.Log ("Something Hit " + raycastHit.collider.name);
                tableLevel = raycastHit.collider.name;
            }
        }
        UpdateHierarchy();
    }

    private void UpdateHierarchy() {
        
        Matrix4x4 i = Matrix4x4.identity;
        TheRoot.CompositeXform(ref i);

        TheRoot.SetAxisFrame(RootOrg);
        firstTable.SetAxisFrame(firstJoin);
        secondTable.SetAxisFrame(secondJoin);
        thirdTable.SetAxisFrame(thirdJoin);

        // FrontTip.localPosition = secondJoin.localPosition + FrontHeight * secondJoin.up;
        // FrontTip.localRotation = secondJoin.localRotation;
    }

    public string getLevel(){
        return name;
    }
}
