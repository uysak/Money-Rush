using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private bool detectedCollision;

    [SerializeField] Animator animatorObstacle;
    [SerializeField] GameObject MoneyBrokeParticle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.CompareTag("Collected"))
        {
            Instantiate(MoneyBrokeParticle, collision.gameObject.transform.position, collision.gameObject.transform.rotation);
            animatorObstacle.SetBool("isMoneyCollided", true);
            detectedCollision = true;
            Debug.LogError("girdi");
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Collected"))
        {
            collision.gameObject.SetActive(false);
            animatorObstacle.SetBool("isMoneyCollided", false);
            detectedCollision = true;
            Debug.LogError("cikti");
        }   
    }
}
