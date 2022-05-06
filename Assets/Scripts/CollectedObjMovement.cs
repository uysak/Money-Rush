using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjMovement : MonoBehaviour
{
    public GameObject ConnectedObj;  //this gameobject will be assigned in CollisionController script when two objects collide

    public Vector3 targetPos;
    private float trackOffset = 0.1f;

    void Update()
    {
        targetPos = new Vector3(ConnectedObj.transform.position.x, ConnectedObj.transform.position.y, ConnectedObj.transform.position.z + trackOffset);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 0.1f);


      //  this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, ConnectedObj.transform.position.x, 0.1f), Mathf.Lerp(this.transform.position.y, ConnectedObj.transform.position.y, 0.1f), ConnectedObj.transform.position.z + 0.5f);
    }
}
