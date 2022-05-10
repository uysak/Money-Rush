using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int necessaryMoney;
    private int currentMoney;
    public bool isGameFailed;

    private AnimationManager animationManagerScript;

    private Boss bossScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;

    private GameObject CollectedObjects;
    private MoneyBar moneyBarScript;

    // Start is called before the first frame update
    void Start()
    {
        animationManagerScript = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationManager>();
        bossScript = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        necessaryMoney = 2000;
        currentMoney = 0;

        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBar>();
        CollectedObjects = GameObject.FindGameObjectWithTag("CollectedObjects");

        moneyBarScript.SetMaxMoney(necessaryMoney);
    }

    private void FixedUpdate()
    {
        AnimateControl();
    }

    public void MoneyCollide(GameObject HitterObj, GameObject HittenObj)
    {
        {

            HittenObj.gameObject.transform.SetParent(CollectedObjects.transform);
            HittenObj.gameObject.tag = "Collected";

            HittenObj.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            HitterObj.gameObject.GetComponent<BoxCollider>().isTrigger = false;


            HittenObj.gameObject.GetComponent<CollectibleObjMovementController>().enabled = false;
            HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().enabled = true;
            HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().ConnectedObj = HitterObj.gameObject;

            HittenObj.gameObject.GetComponent<CollisionController>().enabled = true;

            if(CollectedObjects.transform.childCount == 2)
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().trackOffset = -0.5f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().smoothEffect = 1f;
            }
            else
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().trackOffset = 0.5f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementManager>().smoothEffect = 0.1f;
            }

            moneyBarScript.SetCurrentMoney(currentMoney += 100);
        }
    }

    public void AnimateControl()
    {
        if (CollectedObjects.transform.childCount == 1)
        {
            animationManagerScript.PlayRunAnimation();
        }

        else
            animationManagerScript.PlayCarryAnimation();
         //   animatorPlayer.SetBool("isHaveMoney", true);

        if (isGameFailed == true)
        {
            animationManagerScript.PlayPrayAnimation();
        }

    }
    public void ObstacleCollide(GameObject HitterObj, GameObject ObstacleObj)
    {
        Instantiate(MoneyBrokeParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        ObstacleObj.gameObject.GetComponent<ObstacleController>().AttackAnimate();

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeEffect>().ShakeCamera();

        moneyBarScript.SetCurrentMoney(currentMoney -= 100);

        if(!HitterObj.CompareTag("Player"))
        {
            HitterObj.GetComponent<CollectedObjMovementManager>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
            // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
            Destroy(HitterObj);
        }

    }

    public void FinishLine(GameObject HitterObj)
    {
        Instantiate(PayMoneyParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        if (HitterObj.CompareTag("Player"))
        {
            Debug.LogWarning("Current Money: " + currentMoney);
            if(currentMoney <= necessaryMoney)
            {
                Debug.LogWarning("fail");
                isGameFailed = true;
                animationManagerScript.PlayPrayAnimation();
                HitterObj.GetComponent<PlayerMovementController>().enabled = false;
                bossScript.WalkToPlayer();
                animationManagerScript.PlayBossWalkAnimation();
            }
        }
        else
        {
            HitterObj.GetComponent<CollectedObjMovementManager>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(HitterObj);
        }

    }
}
