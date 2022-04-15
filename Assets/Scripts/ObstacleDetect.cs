using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Collectible")) 
        {
            this.gameObject.tag = "Player";

            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;

            other.gameObject.GetComponent<CollectibleMovement>().enabled = true;
            other.gameObject.GetComponent<CollectibleMovement>().TrackObj = this.gameObject;
            Destroy(this.gameObject.GetComponent<ObstacleDetect>());
            other.gameObject.AddComponent<ObstacleDetect>();




        }
    }
}
