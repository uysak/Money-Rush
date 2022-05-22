using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CollectibleObject : MonoBehaviour
{

    CollectedObjectManager collectedObjectManagerScript;
    public int indexOnList;

    private bool wait;

    // Start is called before the first frame update
    void Start()
    {
        collectedObjectManagerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectedObjectManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ( this.gameObject.CompareTag("Collectible") && (other.gameObject.CompareTag("Collected")) || other.gameObject.CompareTag("Player") )
        // Prevents collected objects from colliding with each other when DOScale
        {
            this.gameObject.tag = "Collected";
            indexOnList = collectedObjectManagerScript.getCollectedObjectCount();
            collectedObjectManagerScript.CollideObject(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            collectedObjectManagerScript.ObstacleCollision(this.gameObject);
        }
        else if (other.gameObject.CompareTag("FinishLine"))
        {
            collectedObjectManagerScript.FinishLine(this.gameObject);
        }
    }

    public void SetBigger()
    {
            this.transform.DOScale(1.3f, (collectedObjectManagerScript.getCollectedObjectCount() - indexOnList) * 0.08f).OnComplete(() =>
            this.transform.DOScale(1f, (collectedObjectManagerScript.getCollectedObjectCount() - indexOnList) * 0.02f));   
    }

    public void SetSmall()
    {
        this.transform.DOScale(0.1f, 1f).SetEase(Ease.OutSine).OnComplete( ()=> Destroy(this.gameObject));
        
    }

}
