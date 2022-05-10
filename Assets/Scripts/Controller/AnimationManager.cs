using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator bossAnimator;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }


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

    public void PlayBossWalkAnimation()
    {
        bossAnimator.SetBool("Walk", true);
    }
}
