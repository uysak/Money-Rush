using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectDetect : MonoBehaviour
{

    private SpawnManager spawnManagerScript;

    private void Start()
    {
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Collectible")) 
        {
            Debug.LogError("detected");
            spawnManagerScript.SpawnMoney();

            other.gameObject.tag = "Collected";
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;

            other.gameObject.GetComponent<CollectedObjMovement>().enabled = true;
            other.gameObject.GetComponent<CollectedObjMovement>().TrackObj = this.gameObject;
            Destroy(this.gameObject.GetComponent<CollectDetect>());
            other.gameObject.AddComponent<CollectDetect>();




        }
    }
}
