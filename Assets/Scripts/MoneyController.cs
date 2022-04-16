using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    SpawnManager spawnManagerScript;

    private GameObject PlayerObj;
    private float differenceBetweenMoneyandPlayer;

    private void Start()
    {
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
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
            spawnManagerScript.SpawnMoney();
        }
    }

}
