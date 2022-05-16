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

        bossAnimator.SetBool("Yelling", true);
    }
    public void PlayObstacleAttackAnimation(GameObject obstacle)
    {
        obstacleAnimator = obstacle.GetComponent<Animator>();
        obstacleAnimator.Play("Base Layer.Attack");
    }
}
