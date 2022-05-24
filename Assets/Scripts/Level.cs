using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameObject CollectibleObjects;
    private int collectibleObjCount;
    private int totalMoneyPrice = 0;
    private int necessaryMoney;




    private void CalculateNecessaryMoney()
    {
        totalMoneyPrice = 0;

        CollectibleObjects = GameObject.Find("CollectibleObjects");

        for (int index = 0; index < CollectibleObjects.transform.childCount; index++)
        {
            totalMoneyPrice += CollectibleObjects.transform.GetChild(index).GetComponent<CollectibleObject>().getPrice();
        }
        necessaryMoney = totalMoneyPrice / 100 * 40;

        Debug.Log("Total Money Price:" + totalMoneyPrice);
        Debug.Log("Calculated neccessary money " + necessaryMoney);
    }
    public int getNecessaryMoney()
    {
        CalculateNecessaryMoney();

        return necessaryMoney;
    }


}
