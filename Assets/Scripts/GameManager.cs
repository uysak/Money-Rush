using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int necessaryMoney;
    private int currentMoney;

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;

    private GameObject CollectedObjects;
    private MoneyBar moneyBarScript;

    // Start is called before the first frame update
    void Start()
    {
        necessaryMoney = 2000;
        currentMoney = 0;

        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBar>();
        CollectedObjects = GameObject.FindGameObjectWithTag("CollectedObjects");

        moneyBarScript.SetMaxMoney(necessaryMoney);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void MoneyCollide(GameObject HitterObj, GameObject HittenObj)
    {
        HittenObj.gameObject.transform.SetParent(CollectedObjects.transform);
        HittenObj.gameObject.tag = "Collected";

        HittenObj.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        HitterObj.gameObject.GetComponent<BoxCollider>().isTrigger = false;


        HittenObj.gameObject.GetComponent<CollectibleObjMovementController>().enabled = false;
        HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().enabled = true;
        HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().ConnectedObj = HitterObj.gameObject;

        HittenObj.gameObject.GetComponent<CollisionController>().enabled = true;


        moneyBarScript.SetCurrentMoney(currentMoney += 100);

    }
    public void ObstacleCollide(GameObject HitterObj, GameObject ObstacleObj)
    {
        Instantiate(MoneyBrokeParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        ObstacleObj.gameObject.GetComponent<ObstacleController>().AttackAnimate();
        HitterObj.GetComponent<CollectedObjMovementManager>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
        // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
        Destroy(HitterObj);
    }

    public void FinishLine(GameObject HitterObj)
    {
        Instantiate(PayMoneyParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        HitterObj.GetComponent<CollectedObjMovementManager>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
        Destroy(HitterObj);
    }
}
