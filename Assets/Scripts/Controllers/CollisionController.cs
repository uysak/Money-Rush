using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private GameManager gameManagerScript;

    [SerializeField] GameObject MoneyBrokeParticleObj;


    private void Start()
    {
        gameManagerScript = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            gameManagerScript.MoneyCollide(this.gameObject, other.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            gameManagerScript.ObstacleCollide(this.gameObject, other.gameObject);
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            gameManagerScript.FinishLine(this.gameObject);
        }
        
    }

   
}
