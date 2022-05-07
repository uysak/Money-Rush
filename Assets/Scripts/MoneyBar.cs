using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyBar : MonoBehaviour
{
    public int necessaryMoney;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.value = 0;
    }

    public void SetMaxMoney(int necessaryMoney)
    {
        this.necessaryMoney = necessaryMoney;
        slider.maxValue = necessaryMoney;
    }
    public void SetCurrentMoney(int currentMoney)
    {
        slider.value = currentMoney;
    }
}
