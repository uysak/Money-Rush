using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyBarController : MonoBehaviour
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
        slider.maxValue = necessaryMoney;
    }
    public void SetCurrentMoney(int currentMoney)
    {
        slider.DOValue(currentMoney, 1, false);
    }
}
