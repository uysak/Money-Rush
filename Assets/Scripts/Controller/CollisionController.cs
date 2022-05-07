using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameObject CollectedObjects;


    private GameManager gameManagerScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;


    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Collectible"))
        {
            gameManagerScript.MoneyCollide(this.gameObject, other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManagerScript.ObstacleCollide(this.gameObject, other.gameObject);
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            gameManagerScript.FinishLine(this.gameObject);
        }
        
    }

    //private void MoneyCollide(GameObject HitterObj, GameObject HittenObj)
    //{
    //    HittenObj.gameObject.transform.SetParent(CollectedObjects.transform);
    //    HittenObj.gameObject.tag = "Collected";

    //    HittenObj.gameObject.GetComponent<BoxCollider>().isTrigger = true;
    //    HitterObj.gameObject.GetComponent<BoxCollider>().isTrigger = false;


    //    HittenObj.gameObject.GetComponent<CollectibleObjMovementController>().enabled = false;
    //    HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().enabled = true;
    //    HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().ConnectedObj = HitterObj.gameObject;

    //    HittenObj.gameObject.GetComponent<CollisionController>().enabled = true;

    //}

    //private void ObstacleCollide(GameObject HitterObj, GameObject ObstacleObj)
    //{
    //    Instantiate(MoneyBrokeParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
    //    ObstacleObj.gameObject.GetComponent<ObstacleController>().AttackAnimate();
    //    HitterObj.GetComponent<CollectedObjMovementManager>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
    //    // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
    //    Destroy(this.gameObject);

    //}
}
