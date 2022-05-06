using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameObject CollectedObjects;
    private SpawnManager spawnManagerScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;


    private void Start()
    {
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        CollectedObjects = GameObject.Find("CollectedObjects");
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.transform.SetParent(CollectedObjects.transform);

        //    spawnManagerScript.SpawnMoney();

            other.gameObject.tag = "Collected";
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            this.gameObject.GetComponent<BoxCollider>().isTrigger = false;

            other.gameObject.GetComponent<CollectedObjMovement>().enabled = true;
            other.gameObject.GetComponent<CollectedObjMovement>().ConnectedObj = this.gameObject;
            this.gameObject.GetComponent<CollisionController>().enabled = false;
            other.gameObject.GetComponent<CollisionController>().enabled = true;

            other.gameObject.GetComponent<CollectibleObjectMovement>().enabled = false;


          //  Destroy(this.gameObject.GetComponent<CollectDetect>());
         //   other.gameObject.AddComponent<CollectDetect>();
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            other.gameObject.GetComponent<ObstacleController>().AttackAnimate();
            Instantiate(MoneyBrokeParticleObj, this.transform.position, this.gameObject.transform.rotation);
            this.GetComponent<CollectedObjMovement>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;

            Destroy(this.gameObject);
        }



        
    }
}
