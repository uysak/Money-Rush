using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject PlayerObj;
    private Transform playerTransform;
    Vector3 targetPos;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = PlayerObj.GetComponent<Transform>();
        
       // offset = this.transform.position - playerTransform.position ;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, playerTransform.position + offset, Time.deltaTime * 2);
    }
}
