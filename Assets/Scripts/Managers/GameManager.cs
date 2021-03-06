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
//    private GameObject CollectedObjects;

    private AnimationController animationControllerScript;
    private CollectedObjectManager collectedObjectManagerScript;
    private Level levelScript;
    private CameraController cameraControllerScript;

    private Boss bossScript;
    private UIManager uiManagerScript; 

    [SerializeField] GameObject MoneyBrokeParticleObj;
    [SerializeField] GameObject PayMoneyParticleObj;

    private MoneyBarController moneyBarScript;

    // Start is called before the first frame update
    void Start()
    {

        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        playerStartPos = PlayerObj.transform.position;
        playerStartRotation = PlayerObj.transform.rotation;
        UIManager = GameObject.FindGameObjectWithTag("UIManager");

        cameraControllerScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        levelScript = this.GetComponent<Level>();
        collectedObjectManagerScript = PlayerObj.GetComponent<CollectedObjectManager>();
        animationControllerScript = GameObject.FindGameObjectWithTag("AnimationManager").GetComponent<AnimationController>();
        uiManagerScript = UIManager.GetComponent<UIManager>();

        currentMoney = 0;
    }
   
    public void FinishLine(GameObject HitterObj)
    {
        Instantiate(PayMoneyParticleObj, HitterObj.transform.position, HitterObj.gameObject.transform.rotation);
        if(currentMoney < necessaryMoney)
        {
            GameOver();
         
        }
        
        else
        {
            LevelSuccessful();
        }
        
    }

    public void CheckPlayerRunOrCarry()
    {
        if(collectedObjectManagerScript.getCollectedObjectCount() == 0)
        {
            animationControllerScript.PlayRunAnimation();
        }
        else
        {
            animationControllerScript.PlayCarryAnimation();
        }
    }

    public void StartGame()
    {
        uiManagerScript.SetUnvisibleStartGamePanel();
        uiManagerScript.SetVisibleMoneyBar();

        animationControllerScript.PlayBossIdleAnimation();
        animationControllerScript.PlayRunAnimation();
    
        
        SetAssignmentGameScene();

        cameraControllerScript.StartGamePos();
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGameStarted = true;
        currentMoney = 0;
        moneyBarScript.SetCurrentMoney(0);
        necessaryMoney = levelScript.getNecessaryMoney();
        moneyBarScript.SetMaxMoney(necessaryMoney);

    }

    public void ShakeCamera()
    {
        cameraControllerScript.ShakeCamera();
    }


    public void IncreaseScore(int Price)
    {
        currentMoney += Price;
        moneyBarScript.SetCurrentMoney(currentMoney);
    }

    public void DecreaseScore(int Price)
    {
        if( currentMoney > 0)
            currentMoney -= Price;
        moneyBarScript.SetCurrentMoney(currentMoney);
    }


    public void RestartGame()
    {
        uiManagerScript.SetUnvisibleGameOverPanel();
        isAssignmentSuccesful = false;
        PlayerObj.transform.position = playerStartPos;
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.GetComponent<BoxCollider>().isTrigger = true;
        animationControllerScript.PlayRunAnimation();
        cameraControllerScript.StartGamePos();
        currentMoney = 0;
        moneyBarScript.SetCurrentMoney(currentMoney);
    }

    public void NextLevel()
    {
        necessaryMoney = levelScript.getNecessaryMoney();
        moneyBarScript.SetMaxMoney(necessaryMoney);

        uiManagerScript.SetUnvisibleCongratulationsPanel();
        uiManagerScript.SetVisibleMoneyBar();

        animationControllerScript.PlayBossIdleAnimation();
        animationControllerScript.PlayRunAnimation();

        SetAssignmentGameScene();
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.transform.position = new Vector3(0, 0.9f, -10f);
        PlayerObj.transform.rotation = new Quaternion(0, 0, 0, 0);
        isGameStarted = true;
        currentMoney = 0;
        moneyBarScript.SetCurrentMoney(0);
        cameraControllerScript.StartGamePos();
    }
    public void GameOver()
    {
        PlayerObj.transform.LookAt(BossObj.transform);
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        uiManagerScript.SetVisibleGameOverPanel();
        isGameStarted = false;
        animationControllerScript.PlayBossYellingAnimation();
        animationControllerScript.PlayPrayAnimation();
        cameraControllerScript.GameFinishPos();
    }
    public void LevelSuccessful() 
    {
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        uiManagerScript.SetVisibleCongratulationsPanel();
        isGameStarted = false;
        animationControllerScript.PlayAJDanceAnimation();
        animationControllerScript.PlayBossDanceAnimation();
        cameraControllerScript.GameFinishPos();
    }

    public void SetAssignmentGameScene()
    {
        BossObj = GameObject.FindGameObjectWithTag("Boss");
        bossScript = BossObj.GetComponent<Boss>();
        Canvas = GameObject.Find("Canvas");
        gameOverPanel = Canvas.transform.GetChild(2).gameObject;
        congratulationsPanel = Canvas.transform.GetChild(3).gameObject;
        moneyBarScript = GameObject.FindGameObjectWithTag("MoneyBar").GetComponent<MoneyBarController>();
        necessaryMoney = levelScript.getNecessaryMoney();
        moneyBarScript.SetMaxMoney(necessaryMoney);
        isAssignmentSuccesful = true;
    }

    public void GameOverBecauseObstacle()
    {
        animationControllerScript.PlayFallingDownAnimation();
        uiManagerScript.SetVisibleGameOverPanel();
        PlayerObj.GetComponent<PlayerMovementController>().enabled = false;
        isGameStarted = false;
        collectedObjectManagerScript.DestroyAllCollectedObjects();

    }

}