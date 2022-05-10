using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjMovementManager : MonoBehaviour
{
    public GameObject ConnectedObj;  //this gameobject will be assigned in CollisionController script when two objects collide


    public Vector3 targetPos;
    public float trackOffset = 0.5f;
    public float smoothEffect = 0.1f;



    void Update()
    {
   //     targetPos = new Vector3(ConnectedObj.transform.position.x, ConnectedObj.transform.position.y, ConnectedObj.transform.position.z + trackOffset);
   //     this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 5 * Time.deltaTime);
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, ConnectedObj.transform.position.x, smoothEffect), Mathf.Lerp(this.transform.position.y, ConnectedObj.transform.position.y, smoothEffect), ConnectedObj.transform.position.z + trackOffset);
    }
}
