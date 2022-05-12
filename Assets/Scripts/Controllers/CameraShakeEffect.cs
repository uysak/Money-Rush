using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeEffect : MonoBehaviour
{

    [SerializeField] float shakeFrequency;
    // Start is called before the first frame update
    void Start()
    {
        shakeFrequency = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShakeCamera()
    {
        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;
        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;
        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;
    }
}
