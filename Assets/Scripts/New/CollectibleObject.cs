using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{

    CollectedObjectManager collectedObjectManagerScript;
    public int indexOnList; 

    // Start is called before the first frame update
    void Start()
    {
        collectedObjectManagerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjectManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            indexOnList = collectedObjectManagerScript.getCollectedObjectCount();
            collectedObjectManagerScript.CollideObject(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            collectedObjectManagerScript.ObstacleCollision(this.gameObject);
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            collectedObjectManagerScript.FinishLine(this.gameObject);
        }
    }


}
