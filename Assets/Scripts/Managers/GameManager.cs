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
    private GameObject congratulationsPanel;
    private GameObject PlayerObj;
    private GameObject BossObj;
    private GameObject UIManager;
    private GameObject CollectedObjects;

    private AnimationController animationControllerScript;

    private Boss bossScript;
    private UIManager uiManagerScript; 

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;


    private MoneyBarController moneyBarScript;

    public Scene sceneTest;

    // Start is called before the first frame update
    void Start()
    {
        sceneTest = SceneManager.GetSceneByBuildIndex(1);
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        playerStartPos = PlayerObj.transform.position;
        playerStartRotation = PlayerObj.transform.rotation;
        UIManager = GameObject.FindGameObjectWithTag("UIManager");

        animationControllerScript = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationController>();
        uiManagerScript = UIManager.GetComponent<UIManager>();
        necessaryMoney = 500;
        currentMoney = 0;
    }
    private void FixedUpdate()
    {
        //if(isGameStarted == true)
        //{
        //    AnimateControl();
        //}

    //    Debug.LogWarning(CollectedObjects.transform.childCount);

        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3) && isAssignmentSuccesful == false)
        {
            StartGame();
        }
    }
    public void MoneyCollide(GameObject HitterObj, GameObject HittenObj)
    {
        {
            HittenObj.gameObject.transform.SetParent(CollectedObjects.transform);
            HittenObj.gameObject.tag = "Collected";

            AnimateControl();

            HittenObj.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            HitterObj.gameObject.GetComponent<BoxCollider>().isTrigger = false;


            HittenObj.gameObject.GetComponent<CollectibleObjMovementController>().enabled = false;
            HittenObj.gameObject.GetComponent<CollectedObjMovementController>().enabled = true;
            HittenObj.gameObject.GetComponent<CollectedObjMovementController>().ConnectedObj = HitterObj.gameObject;

            HittenObj.gameObject.GetComponent<CollisionController>().enabled = true;

            if(CollectedObjects.transform.childCount == 1)
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = -0.45f;
            //    HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 0f;
            }
            else
            {
                HittenObj.gameObject.GetComponent<CollectedObjMovementController>().trackOffset = 0.5f;
              //  HittenObj.gameObject.GetComponent<CollectedObjMovementController>().smoothEffect = 0.04f;
            }

            moneyBarScript.SetCurrentMoney(currentMoney += 100);
        }
    }

    public void AnimateControl()
    {
        if ( CollectedObjects.transform.childCount == 0)
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
            uiManagerScript.SetVisibleGameOverPanel();
            PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
            isGameStarted = false;


        }
        else
        {
            // The object at the end of the queue has been destroyed, we are adding an object detection feature to the object it is connected to.
            HitterObj.GetComponent<CollectedObjMovementController>().ConnectedObj.GetComponent<BoxCollider>().isTrigger = true;
            Destroy(HitterObj);
        }
        AnimateControl();
    }

    public void FinishLine(GameObject HitterObj)
    {
        Instantiate(PayMoneyParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        if (HitterObj.CompareTag("Player"))
        {
            if(currentMoney < necessaryMoney)
            {
                GameOver();
            }
            else
            {
                LevelSuccessful();
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
        uiManagerScript.SetUnvisibleStartGamePanel();
        uiManagerScript.SetVisibleMoneyBar();

        animationControllerScript.PlayBossIdleAnimation();
        animationControllerScript.PlayRunAnimation();



        SetAssignmentGameScene();
        PlayerObj.GetComponent<CollisionController>().enabled = true;
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGameStarted = true;
        currentMoney = 0;
        moneyBarScript.SetCurrentMoney(0);
    }


    public void RestartGame()
    {
        uiManagerScript.SetUnvisibleGameOverPanel();
        isAssignmentSuccesful = false;
        PlayerObj.transform.position = playerStartPos;
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.GetComponent<BoxCollider>().isTrigger = true;
    }

    public void GameOver()
    {
        PlayerObj.transform.LookAt(BossObj.transform);
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        uiManagerScript.SetVisibleGameOverPanel();
        isGameStarted = false;
        animationControllerScript.PlayBossYellingAnimation();
        animationControllerScript.PlayPrayAnimation();
    }
    public void LevelSuccessful() 
    {
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        uiManagerScript.SetVisibleCongratulationsPanel();
        isGameStarted = false;
        animationControllerScript.PlayAJDanceAnimation();
        animationControllerScript.PlayBossDanceAnimation();
    }

    public void SetAssignmentGameScene()
    {
        BossObj = GameObject.FindGameObjectWithTag("Boss");
        bossScript = BossObj.GetComponent<Boss>();
        Canvas = GameObject.Find("Canvas");
        gameOverPanel = Canvas.transform.GetChild(2).gameObject;
        congratulationsPanel = Canvas.transform.GetChild(3).gameObject;
        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBarController>();
        CollectedObjects = GameObject.FindGameObjectWithTag("CollectedObjects");
        moneyBarScript.SetMaxMoney(necessaryMoney);
        isAssignmentSuccesful = true;
    }

}