using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyController : MonoBehaviour
{
    SpawnManager spawnManagerScript;

    private GameObject PlayerObj;
    private float differenceBetweenMoneyandPlayer;

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        differenceBetweenMoneyandPlayer = PlayerObj.transform.position.z - this.transform.position.z;
        CheckOutsideBorder();
    }

    void CheckOutsideBorder()
    {
        if(differenceBetweenMoneyandPlayer > 10)
        {
            Destroy(this.gameObject);
      //      spawnManagerScript.SpawnMoney();
        }
    }

}
