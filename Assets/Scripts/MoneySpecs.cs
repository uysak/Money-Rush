using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySpecs : MonoBehaviour
{
    public int queueIndex;
    private GameObject CollectedObjects;
    // Start is called before the first frame update
    void Start()
    {
        CollectedObjects = GameObject.Find("CollectedObjects");
        queueIndex = CollectedObjects.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
