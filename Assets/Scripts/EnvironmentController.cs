using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    private GameObject PlayerObj;
    private GameObject RoadObj;

    private int offset = 197;

    void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        RoadObj = GameObject.FindGameObjectWithTag("Road");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RoadObj.transform.position += new Vector3(0, 0, 5 * Time.deltaTime);
    }
}
