using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private Vector3 playerStartPos;

    private int necessaryMoney;
    private int currentMoney;
    public bool isGameFailed;

    private GameObject Canvas;
    private GameObject gameOverPanel;

    private AnimationController animationControllerScript;

    private Boss bossScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;

    private GameObject CollectedObjects;
    private MoneyBarController moneyBarScript;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPos = GameObject.Find("Player").transform.position;
        Canvas = GameObject.Find("Canvas");

        animationControllerScript = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationController>();
        bossScript = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();

        gameOverPanel = Canvas.transform.GetChild(1).gameObject;

        necessaryMoney = 2000;
        currentMoney = 0;

        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBarController>();
        CollectedObjects = GameObject.FindGameObjectWithTag("CollectedObjects");

        moneyBarScript.SetMaxMoney(necessaryMoney);


    }
    
    private void Awake()
    {
        
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
            HittenObj.gameObject.GetComponent<CollectedObjMovementController>().enabled = true;
            HittenObj.gameObject.GetComponent<CollectedObjMovementController>().ConnectedObj = HitterObj.gameObject;

            HittenObj.gameObject.GetComponent<CollisionController>().enabled = true;

            if(CollectedObjects.transform.childCount == 2)
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = -0.5f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 1f;
            }
            else
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = 0.5f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 0.1f;
            }

            moneyBarScript.SetCurrentMoney(currentMoney += 100);
        }
    }

    public void AnimateControl()
    {
        if (CollectedObjects.transform.childCount == 1)
        {
            animationControllerScript.PlayRunAnimation();
        }

        else
            animationControllerScript.PlayCarryAnimation();
         //   animatorPlayer.SetBool("isHaveMoney", true);

        if (isGameFailed == true)
        {
            animationControllerScript.PlayPrayAnimation();
        }

    }
    public void ObstacleCollide(GameObject HitterObj, GameObject ObstacleObj)
    {
        Instantiate(MoneyBrokeParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        animationControllerScript.PlayObstacleAttackAnimation(ObstacleObj);

        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShakeEffect>().ShakeCamera();

        moneyBarScript.SetCurrentMoney(currentMoney -= 100);

        if(!HitterObj.CompareTag("Player"))
        {
            HitterObj.GetComponent<CollectedObjMovementController>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
            // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
            Destroy(HitterObj);
        }

    }

    public void FinishLine(GameObject HitterObj)
    {
        Instantiate(PayMoneyParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        if (HitterObj.CompareTag("Player"))
        {
            if(currentMoney <= necessaryMoney)
            {
//                isGameFailed = true;
                HitterObj.GetComponent<PlayerMovementController>().enabled = false;

                animationControllerScript.PlayPrayAnimation();
                animationControllerScript.PlayBossYellingAnimation();


                gameOverPanel.SetActive(true);
            }
        }
        else
        {
            HitterObj.GetComponent<CollectedObjMovementController>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true; // 
            Destroy(HitterObj);
        }

    }


    private void StartGame()
    {
        GameObject.Find("Player").transform.position = playerStartPos;
    }
}