using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject MoneyObj;
    public GameObject SpawnedMoney;
    private GameObject CollectibleObjects;

    private int minSpawnPosX = - 3;
    private int maxSpawnPosX = 3;

    private int spawnPosX;

    private int lastMoneySpawnPosZ = 120;

    void Start()
    {
        CollectibleObjects = GameObject.Find("CollectibleObjects");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMoney()
    {
        lastMoneySpawnPosZ += 5;
        spawnPosX = Random.RandomRange(minSpawnPosX, maxSpawnPosX);
        
        SpawnedMoney = Instantiate(MoneyObj, new Vector3(spawnPosX, 0.3f, lastMoneySpawnPosZ),MoneyObj.transform.rotation, CollectibleObjects.transform);
//        SpawnedMoney.AddComponent<MoneyController>();

    }
}
