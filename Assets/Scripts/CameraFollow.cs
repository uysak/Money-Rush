using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    Vector3 targetPos;
    Vector3 offset;

    private void Start()
    {
        offset = this.transform.position - playerTransform.position ;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, playerTransform.position + offset, Time.deltaTime * 2);
    }
}
