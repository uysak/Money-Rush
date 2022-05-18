using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public bool isGameStarted;

    public Vector3 playerStartPos;
    public Quaternion playerStartRotation;

    private int necessaryMoney;
    private int currentMoney;
    public bool isGameFailed;
    public bool isAssignmentSuccesful;


    private GameObject Canvas;
    private GameObject gameOverPanel;
    private GameObject PlayerObj;
    private GameObject BossObj;

    private AnimationController animationControllerScript;

    private Boss bossScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;

    private GameObject CollectedObjects;
    private MoneyBarController moneyBarScript;

    public Scene sceneTest;

    // Start is called before the first frame update
    void Start()
    {
        sceneTest = SceneManager.GetSceneByBuildIndex(1);
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        playerStartPos = PlayerObj.transform.position;
        playerStartRotation = PlayerObj.transform.rotation;

        animationControllerScript = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationController>();

        necessaryMoney = 2000;
        currentMoney = 0;
    }
    private void FixedUpdate()
    {
        if(isGameStarted == true)
        {
            AnimateControl();
        }
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1) && isAssignmentSuccesful == false)
        {
            StartGame();
        }
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

            if(CollectedObjects.transform.childCount == 1)
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = -0.45f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 0f;
            }
            else
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = 0.5f;
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 0.04f;
            }

            moneyBarScript.SetCurrentMoney(currentMoney += 100);
        }
    }

    public void AnimateControl()
    {
        if (CollectedObjects.transform.childCount == 0)
        {
            animationControllerScript.PlayRunAnimation();
        }

        else
            animationControllerScript.PlayCarryAnimation();

    }
    public void ObstacleCollide(GameObject HitterObj, GameObject ObstacleObj)
    {
        Instantiate(MoneyBrokeParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().ShakeCamera();

        moneyBarScript.SetCurrentMoney(currentMoney -= 100);


        if(HitterObj.CompareTag("Player"))
        {

            animationControllerScript.PlayFallingDownAnimation();
            gameOverPanel.SetActive(true);
            PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
            isGameStarted = false;


        }
        else
        {
            // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
            HitterObj.GetComponent<CollectedObjMovementController>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
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
                animationControllerScript.PlayPrayAnimation();
                animationControllerScript.PlayBossYellingAnimation();
                PlayerObj.transform.LookAt(BossObj.transform);
                GameOver();
            }
        }
        else
        {
            HitterObj.GetComponent<CollectedObjMovementController>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true; // 
            Destroy(HitterObj);
        }
    }

    public void StartGame()
    {
        animationControllerScript.PlayRunAnimation();
        SetAssignmentGameScene();
        PlayerObj.GetComponent<CollisionController>().enabled = true;
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGameStarted = true;
        currentMoney = 0;
        moneyBarScript.SetCurrentMoney(0);
    }

    public void GameOver()
    {
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        gameOverPanel.SetActive(true);
        isGameStarted = false;
        animationControllerScript.PlayPrayAnimation();
    }

    public void SetAssignmentGameScene()
    {
        BossObj = GameObject.FindGameObjectWithTag("Boss");
        bossScript = BossObj.GetComponent<Boss>();
        Canvas = GameObject.Find("Canvas");
        gameOverPanel = Canvas.transform.GetChild(2).gameObject;
        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBarController>();
        CollectedObjects = GameObject.FindGameObjectWithTag("CollectedObjects");
        moneyBarScript.SetMaxMoney(necessaryMoney);
        isAssignmentSuccesful = true;
    }

}