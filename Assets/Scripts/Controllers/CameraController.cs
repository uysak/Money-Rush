using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraController : MonoBehaviour
{
    private GameObject PlayerObj;
    private Transform playerTransform;
    Vector3 targetPos;
    [SerializeField] Vector3 offset;
    public float shakeFrequency;
    private void Start()
    {
        shakeFrequency = 0.1f;
        PlayerObj = GameObject.FindGameObjectWithTag("Player");
        playerTransform = PlayerObj.GetComponent<Transform>();
        
       // offset = this.transform.position - playerTransform.position ;
    }
    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, playerTransform.position + offset, Time.deltaTime * 5);
    }

    public void ShakeCamera()
    {
        //this.GetComponent<Camera>().DOShakePosition(0.8f, 1f, 3,40, false);
      
        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;

        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;
        this.transform.position = this.transform.position + Random.insideUnitSphere * shakeFrequency;

    }

    public void StartGamePos()
    {
        offset = new Vector3(0.5f, 3.5f, -5f);
        this.gameObject.transform.rotation = Quaternion.Euler(19f, 0f, 0f);  // Quaternion.Slerp(this.transform.rotation,, 15 * Time.deltaTime); //Quaternion.Lerp(this.transform.rotation, new Quaternion(19.1f, 0f, 0f, 1), 15 * Time.deltaTime);
        this.gameObject.GetComponent<Camera>().fieldOfView = 60;
    }
    public void GameFinishPos()
    {
        offset = new Vector3(6f,2.46f,-6f);
        this.gameObject.transform.rotation = Quaternion.Euler(9, 336, 0);  //Quaternion.Slerp(this.transform.rotation,, 15 * Time.deltaTime);
        this.gameObject.GetComponent<Camera>().fieldOfView = 75;
    }
}
