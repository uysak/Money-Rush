using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField] Animator animatorObstacle;
    private GameObject PlayerObj;

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        this.transform.LookAt(PlayerObj.transform);
    }
    public void AttackAnimate()
    {
    //    animatorObstacle.Play("Base Layer.Attack", 0, 0.15f);
    }

}
