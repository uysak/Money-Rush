using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    private bool detectedMoney;
    private bool wait;

    [SerializeField] Animator animatorObstacle;
    [SerializeField] GameObject MoneyBrokeParticle;

    private GameObject CollectedObjects;
    private GameObject DetectedMoneyObj;

    void Start()
    {
        CollectedObjects = GameObject.Find("CollectedObjects"); 
    }

    // Update is called once per frame
    void Update()
    {
       if(detectedMoney == true)
        {
            wait = true;
            DetectedMoney(DetectedMoneyObj);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        detectedMoney = true;
        DetectedMoneyObj = collision.gameObject;

        //if (collision.gameObject.CompareTag("Collected"))
        //{
        //    Instantiate(MoneyBrokeParticle, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
        //    animatorObstacle.SetBool("isMoneyCollided", true);
        //}
    }


    private void DetectedMoney(GameObject Money)
    {
        Instantiate(MoneyBrokeParticle, Money.gameObject.transform.position, Money.gameObject.transform.rotation);
        animatorObstacle.SetBool("isMoneyCollided", true);
        Destroy(Money);
        FinishCollision();

    }

    private void FinishCollision()
    {
        CollectedObjects.transform.GetChild(CollectedObjects.transform.childCount).gameObject.AddComponent<CollectDetect>();
        animatorObstacle.SetBool("isMoneyCollided", false);
        wait = false;
    }
}







//private void OnCollisionExit(Collision collision)
//{
//    Debug.LogError("detected exit");
//    //if (collision.gameObject.CompareTag("Collected"))
//    //{
//    //    Destroy(collision.gameObject);
//    //    CollectedObjects.transform.GetChild(CollectedObjects.transform.childCount).gameObject.AddComponent<CollectDetect>();
//    //    animatorObstacle.SetBool("isMoneyCollided", false);
//    //}
//}
