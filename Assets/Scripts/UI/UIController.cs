using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject StartGamePanelObj;
    private GameObject GameOverPanelObj;
    [SerializeField] GameObject MoneyBarObj;

    public GameObject PlayerObj;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        StartGamePanelObj = GameObject.FindGameObjectWithTag("StartGamePanel");
        GameOverPanelObj = GameObject.FindGameObjectWithTag("GameOverPanel");
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
     //   MoneyBarObj = GameObject.FindGameObjectWithTag("MoneyBar");
    }
    public void RestartGame()
    {
        GameOverPanelObj = GameObject.FindGameObjectWithTag("GameOverPanel");
        GameOverPanelObj.SetActive(false);
        gameManagerScript.isAssignmentSuccesful = false;
        SceneManager.LoadScene(1);
        GameObject.FindGameObjectWithTag("Player").transform.position = gameManagerScript.playerStartPos;
        PlayerObj.GetComponent<PlayerMovementController>().enabled = true;
        PlayerObj.GetComponent<BoxCollider>().isTrigger = true;
    }
    public void StartGame()
    {
        StartGamePanelObj.SetActive(false);
        MoneyBarObj.SetActive(true);
        SceneManager.LoadScene(1);
    }
}
