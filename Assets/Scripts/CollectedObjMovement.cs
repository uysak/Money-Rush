using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObjMovement : MonoBehaviour
{

    public GameObject TrackObj;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3( Mathf.Lerp(this.transform.position.x,TrackObj.transform.position.x,0.1f), this.transform.position.y  ,TrackObj.transform.position.z + 1);
    }
}
