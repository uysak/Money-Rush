using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public bool detectedMoney;
    private bool wait;

    [SerializeField] Animator animatorObstacle;


    public void AttackAnimate()
    {
        animatorObstacle.Play("Base Layer.Attack", 0, 0.25f);
    }

}
