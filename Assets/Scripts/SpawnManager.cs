using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject MoneyObj;
    public GameObject SpawnedMoney;

    private int minSpawnPosX = - 3;
    private int maxSpawnPosX = 3;

    private int spawnPosX;

    private int lastMoneyObjPosZ = 120;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMoney()
    {
        lastMoneyObjPosZ += 5;
        spawnPosX = Random.RandomRange(minSpawnPosX, maxSpawnPosX);
        
        SpawnedMoney = Instantiate(MoneyObj, new Vector3(spawnPosX, 0.3f, lastMoneyObjPosZ),MoneyObj.transform.rotation);
//        SpawnedMoney.AddComponent<MoneyController>();

    }
}
