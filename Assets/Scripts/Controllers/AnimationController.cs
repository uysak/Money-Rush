using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator bossAnimator;
    private Animator obstacleAnimator;


    public void PlayPrayAnimation()
    {
        playerAnimator.SetBool("isGameFailed", true);
    }

    public void PlayRunAnimation()
    {
        playerAnimator.SetBool("isHaveMoney", false);
    }

    public void PlayCarryAnimation()
    {
        playerAnimator.SetBool("isHaveMoney", true);
    }

    public void PlayBossYellingAnimation()
    {
        bossAnimator.SetBool("Yelling", true);
    }
    public void PlayObstacleAttackAnimation(GameObject obstacle)
    {
        obstacleAnimator = obstacle.GetComponent<Animator>();
        obstacleAnimator.Play("Base Layer.Attack");
    }
}
