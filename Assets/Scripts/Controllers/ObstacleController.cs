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
}
