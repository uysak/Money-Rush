using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private GameObject BossObj;

    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator bossAnimator;
    private Animator obstacleAnimator;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>();
        BossObj = GameObject.FindGameObjectWithTag("Boss");
    }

    public void PlayPrayAnimation()
    {
        playerAnimator.SetBool("isGameStarted", false);
        playerAnimator.SetBool("isGameFailed", true);
    }

    public void PlayRunAnimation()
    {
      //  playerAnimator = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<Animator>();
        playerAnimator.SetBool("isGameStarted", true);
        playerAnimator.SetBool("isHaveMoney", false);
        playerAnimator.SetBool("isGameFailed", false);
        playerAnimator.SetBool("isCollisionObstacle", false);
        playerAnimator.SetBool("isLevelSuccess", false);
    }

    public void PlayCarryAnimation()
    {
        playerAnimator.SetBool("isHaveMoney", true);
    }

    public void PlayBossYellingAnimation()
    {
        if(BossObj == null)
        {
            BossObj = GameObject.FindGameObjectWithTag("Boss");
            bossAnimator = BossObj.GetComponent<Animator>();
        }
        bossAnimator.SetBool("isGameStarted", false);
        bossAnimator.SetBool("Yelling", true);
    }
    public void PlayObstacleAttackAnimation(GameObject obstacle)
    {
        obstacleAnimator = obstacle.GetComponent<Animator>();
        obstacleAnimator.Play("Base Layer.Attack");
    }
    public void PlayFallingDownAnimation()
    {
        playerAnimator.SetBool("isCollisionObstacle", true);
        playerAnimator.SetBool("isGameStarted", false);
        playerAnimator.SetBool("isHaveMoney", false);
    }

    public void PlayAJDanceAnimation()
    {
        playerAnimator.SetBool("isLevelSuccess", true);
        playerAnimator.SetBool("isGameStarted", false);
        playerAnimator.SetBool("isHaveMoney", false);
    }
    public void PlayBossIdleAnimation()
    {
        if(BossObj == null)
        {
            BossObj = GameObject.FindGameObjectWithTag("Boss");
            bossAnimator = BossObj.GetComponent<Animator>();
            bossAnimator.SetBool("isGameStarted", true);
            bossAnimator.SetBool("Yelling", false);
        }
    }

    public void PlayBossDanceAnimation()
    {
        bossAnimator.SetBool("isGameStarted", false);
        bossAnimator.SetBool("isLevelSuccess", true);
    }

}
