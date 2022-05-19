using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjMovementController : MonoBehaviour
{
    public GameObject ConnectedObj;  //this gameobject will be assigned in CollisionController script when two objects collide


    public Vector3 targetPos;
    public float trackOffset ;//0.5f;
    public float smoothEffect;//0.1f;

    private Vector3 velocity = Vector3.zero;
    
    void Update()
    {
        if (ConnectedObj == null)
        {
            Destroy(this.gameObject);
        }
        targetPos = new Vector3(ConnectedObj.transform.position.x, ConnectedObj.transform.position.y, ConnectedObj.transform.position.z + trackOffset);

        //  this.transform.position = Vector3.SmoothDamp(this.transform.position, targetPos, ref velocity , smoothEffect);
        //this.transform.position = Vector3.Lerp(this.transform.position, targetPos, 20f * Time.deltaTime);

        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, ConnectedObj.transform.position.x, 12f * Time.deltaTime), ConnectedObj.transform.position.y, ConnectedObj.transform.position.z + trackOffset);



    }
}
