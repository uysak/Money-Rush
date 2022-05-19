using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameObject Canvas;

    private GameObject StartGamePanelObj;
    private GameObject GameOverPanelObj;
    private GameObject MoneyBarObj;
    private GameObject CongratulationsPanelObj;

    public GameObject PlayerObj;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        PlayerObj = GameObject.FindGameObjectWithTag("Player");

        StartGamePanelObj = Canvas.transform.GetChild(0).gameObject;
        MoneyBarObj = Canvas.transform.GetChild(1).gameObject;
        GameOverPanelObj = Canvas.transform.GetChild(2).gameObject;
        CongratulationsPanelObj = Canvas.transform.GetChild(3).gameObject;

        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(3);
        gameManagerScript.RestartGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    public void SetVisibleGameOverPanel()
    {
        GameOverPanelObj.SetActive(true);
    }

    public void SetUnvisibleGameOverPanel()
    {
        GameOverPanelObj.SetActive(false);
    }

    public void SetVisibleStartGamePanel()
    {
        StartGamePanelObj.SetActive(true);
    }

    public void SetUnvisibleStartGamePanel()
    {
        StartGamePanelObj.SetActive(false);
    }

    public void SetVisibleMoneyBar()
    {
        MoneyBarObj.SetActive(true);
    }
    public void SetUnvisibleMoneyBar()
    {
        MoneyBarObj.SetActive(false);
    }
    public void SetVisibleCongratulationsPanel()
    {
        CongratulationsPanelObj.SetActive(true);
    }

    public void SetUnvisibleCongratulationsPanel()
    {
        CongratulationsPanelObj.SetActive(false);
    }


}
